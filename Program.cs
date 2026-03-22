using ExamDynamicsAPI.Applications.Mappings;
using ExamDynamicsAPI.Applications.Services;
using ExamDynamicsAPI.Applications.Services.Auth;
using ExamDynamicsAPI.Core.Interfaces.Repositories;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using ExamDynamicsAPI.Infrastructure.Repositories;
using ExamDynamicsAPI.Infrastructure.Seeders;
using ExamDynamicsAPI.WebAPI.Middleware;

using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;
using Serilog;

using System.Text;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, _, lc) => lc
        .ReadFrom.Configuration(ctx.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File(
            path: Path.Combine("logs", "examdynamics-.log"),
            rollingInterval: RollingInterval.Day,
            retainedFileCountLimit: 14));

    // ==========================
    // Database
    // ==========================

    if (builder.Environment.IsEnvironment("IntegrationTests"))
    {
        builder.Services.AddDbContext<ExamDynamicsDbContext>(options =>
            options.UseInMemoryDatabase("ExamDynamicsIntegrationTests"));
    }
    else
    {
        builder.Services.AddDbContext<ExamDynamicsDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));
    }

    // ==========================
    // Identity
    // ==========================

    builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
        {
            options.Password.RequiredLength = 6;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = false;
            options.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<ExamDynamicsDbContext>()
        .AddDefaultTokenProviders();

    // ==========================
    // JWT + OAuth (Google / Facebook)
    // ==========================

    var jwtKey = builder.Configuration["Jwt:Key"];
    var jwtIssuer = builder.Configuration["Jwt:Issuer"];
    var jwtAudience = builder.Configuration["Jwt:Audience"] ?? jwtIssuer;

    var authBuilder = builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey!))
        };
    });

    var googleClientId = builder.Configuration["Authentication:Google:ClientId"];
    var googleSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    if (!string.IsNullOrWhiteSpace(googleClientId) && !string.IsNullOrWhiteSpace(googleSecret))
    {
        authBuilder.AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
        {
            options.ClientId = googleClientId;
            options.ClientSecret = googleSecret;
            options.CallbackPath = "/signin-google";
            options.SaveTokens = true;
            options.SignInScheme = IdentityConstants.ExternalScheme;
        });
    }

    var fbAppId = builder.Configuration["Authentication:Facebook:AppId"];
    var fbSecret = builder.Configuration["Authentication:Facebook:AppSecret"];
    if (!string.IsNullOrWhiteSpace(fbAppId) && !string.IsNullOrWhiteSpace(fbSecret))
    {
        authBuilder.AddFacebook(FacebookDefaults.AuthenticationScheme, options =>
        {
            options.AppId = fbAppId;
            options.AppSecret = fbSecret;
            options.CallbackPath = "/signin-facebook";
            options.SaveTokens = true;
            options.SignInScheme = IdentityConstants.ExternalScheme;
            options.Scope.Add("email");
            options.Scope.Add("public_profile");
        });
    }

    // ==========================
    // Caching & health
    // ==========================

    builder.Services.AddMemoryCache();
    builder.Services.AddHealthChecks()
        .AddDbContextCheck<ExamDynamicsDbContext>("database", tags: new[] { "db", "sql" });

    // ==========================
    // Services & Repositories
    // ==========================

    builder.Services.AddHttpClient();

    builder.Services.AddScoped<IChatService, ChatService>();
    builder.Services.AddScoped<ITokenService, TokenService>();
    builder.Services.AddScoped<IAuthPasswordService, AuthPasswordService>();
    builder.Services.AddScoped<IExternalAuthCompletionService, ExternalAuthCompletionService>();

    builder.Services.Configure<EmailSettings>(
        builder.Configuration.GetSection("EmailSettings"));

    builder.Services.AddScoped<IEmailService, EmailService>();

    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();

    builder.Services.AddScoped<IExamService, ExamService>();
    builder.Services.AddScoped<IExamRepository, ExamRepository>();

    builder.Services.AddScoped<IQuestionService, QuestionService>();
    builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();

    builder.Services.AddScoped<IOptionService, OptionService>();
    builder.Services.AddScoped<IOptionRepository, OptionRepository>();

    builder.Services.AddScoped<IAnswerService, AnswerService>();
    builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();

    builder.Services.AddScoped<IContactMessageService, ContactMessageService>();
    builder.Services.AddScoped<IContactMessageRepository, ContactMessageRepository>();

    builder.Services.AddScoped<IActivityLogService, ActivityLogService>();
    builder.Services.AddScoped<IStudentProfileService, StudentProfileService>();
    builder.Services.AddScoped<IPerformanceService, PerformanceService>();

    builder.Services.AddScoped<IExamDynamicsUnitOfWork, ExamDynamicsUnitOfWork>();

    builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

    // ==========================
    // AutoMapper
    // ==========================

    builder.Services.AddAutoMapper(
        typeof(MappingProfile),
        typeof(AnswerProfile));

    // ==========================
    // Controllers
    // ==========================

    builder.Services.AddControllers();

    // ==========================
    // CORS
    // ==========================

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });

    // ==========================
    // OpenAPI / Swagger (Scalar)
    // ==========================

    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "ExamDynamics API",
            Version = "v1",
            Description = "ExamDynamics API Documentation"
        });

        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "Enter JWT Token (Example: Bearer your_token)",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT"
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
    });

    var app = builder.Build();

    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ExamDynamicsDbContext>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

        if (app.Environment.IsEnvironment("IntegrationTests"))
        {
            await dbContext.Database.EnsureCreatedAsync();
        }
        else
        {
            await dbContext.Database.MigrateAsync();
            await DbSeeder.SeedAsync(dbContext, userManager, roleManager);
        }
    }

    if (app.Environment.IsDevelopment())
    {
        app.MapSwagger("/openapi/{documentName}.json");
        app.MapScalarApiReference(options =>
        {
            options.WithTitle("ExamDynamics API");
        });
    }

    app.UseMiddleware<GlobalExceptionMiddleware>();

    app.UseSerilogRequestLogging();

    app.UseHttpsRedirection();

    app.UseCors("AllowAll");

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapHealthChecks("/health", new HealthCheckOptions
    {
        ResponseWriter = async (context, report) =>
        {
            context.Response.ContentType = "application/json";
            var result = System.Text.Json.JsonSerializer.Serialize(new
            {
                status = report.Status.ToString(),
                totalDuration = report.TotalDuration.TotalMilliseconds,
                checks = report.Entries.Select(e => new
                {
                    name = e.Key,
                    status = e.Value.Status.ToString(),
                    description = e.Value.Description,
                    duration = e.Value.Duration.TotalMilliseconds
                })
            });
            await context.Response.WriteAsync(result);
        }
    });

    app.MapControllers();

    Log.Information("ExamDynamics API starting");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

public partial class Program { }
