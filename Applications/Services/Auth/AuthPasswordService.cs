using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace ExamDynamicsAPI.Applications.Services.Auth;

public sealed class AuthPasswordService : IAuthPasswordService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IEmailService _emailService;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthPasswordService> _logger;

    public AuthPasswordService(
        UserManager<ApplicationUser> userManager,
        IEmailService emailService,
        IConfiguration configuration,
        ILogger<AuthPasswordService> logger)
    {
        _userManager = userManager;
        _emailService = emailService;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task RequestPasswordResetAsync(string email, CancellationToken cancellationToken = default)
    {
        var normalized = email.Trim();
        if (string.IsNullOrEmpty(normalized))
            return;

        var user = await _userManager.FindByEmailAsync(normalized);
        if (user == null)
        {
            _logger.LogInformation("Password reset requested for unknown email (suppressed).");
            return;
        }

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        var frontendBase = (_configuration["Frontend:Url"] ?? "http://localhost:4200").TrimEnd('/');
        var resetLink =
            $"{frontendBase}/reset-password?email={Uri.EscapeDataString(user.Email!)}&token={Uri.EscapeDataString(token)}";

        var subject = "Reset your ExamDynamics password";
        var body = $@"
<p>Hi{(string.IsNullOrWhiteSpace(user.FullName) ? "" : " " + user.FullName)},</p>
<p>We received a request to reset your password. Click the link below (valid for a limited time):</p>
<p><a href=""{resetLink}"">Reset password</a></p>
<p>If you did not request this, you can ignore this email.</p>";

        try
        {
            await _emailService.SendEmailAsync(user.Email!, subject, body);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to send password reset email to {Email}", user.Email);
        }
    }

    public async Task<(bool Success, string? Error)> ResetPasswordAsync(
        string email,
        string token,
        string newPassword,
        CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(email.Trim());
        if (user == null)
            return (false, "Invalid reset request.");

        var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
        if (!result.Succeeded)
        {
            var msg = string.Join(" ", result.Errors.Select(e => e.Description));
            return (false, string.IsNullOrWhiteSpace(msg) ? "Could not reset password." : msg);
        }

        return (true, null);
    }
}
