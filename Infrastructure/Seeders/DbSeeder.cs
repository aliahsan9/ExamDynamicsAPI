using ExamDynamicsAPI.Core.Models;
using ExamDynamicsAPI.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExamDynamicsAPI.Infrastructure.Seeders
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(
            ExamDynamicsDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            await context.Database.MigrateAsync();

            var rand = new Random();

            // ==================== Roles ====================
            var roles = new[] { "Admin", "Student" };
            foreach (var roleName in roles)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new ApplicationRole
                    {
                        Name = roleName,
                        Description = $"{roleName} role"
                    });
                }
            }

            // ==================== Users ====================
            var adminUser = await userManager.FindByEmailAsync("admin@example.com");
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = "admin",
                    FullName = "Admin User",
                    Email = "admin@example.com",
                    CreatedAt = DateTime.UtcNow,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(adminUser, "Admin@123");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            var studentUser = await userManager.FindByEmailAsync("student@example.com");
            if (studentUser == null)
            {
                studentUser = new ApplicationUser
                {
                    UserName = "student",
                    FullName = "Student User",
                    Email = "student@example.com",
                    CreatedAt = DateTime.UtcNow,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(studentUser, "Student@123");
                await userManager.AddToRoleAsync(studentUser, "Student");
            }

            // ==================== User Profiles ====================
            if (!context.UserProfiles.Any())
            {
                foreach (var user in context.Users.ToList())
                {
                    context.UserProfiles.Add(new UserProfile
                    {
                        UserId = user.Id,
                        Bio = $"This is {user.FullName}'s bio",
                        ProfilePictureUrl = null!
                    });
                }
                await context.SaveChangesAsync();
            }

            // ==================== Exams ====================
            if (!context.Exams.Any())
            {
                var exams = new List<Exam>
                {
                    new Exam { Title = "Math Exam", Description = "Basic math test", CreatedAt = DateTime.UtcNow },
                    new Exam { Title = "Science Exam", Description = "Basic science test", CreatedAt = DateTime.UtcNow },
                    new Exam { Title = "English Exam", Description = "English grammar test", CreatedAt = DateTime.UtcNow }
                };
                context.Exams.AddRange(exams);
                await context.SaveChangesAsync();
            }  

            // ==================== Exam Categories ====================
            if (!context.ExamCategories.Any())
            {
                foreach (var exam in context.Exams.ToList())
                {
                    context.ExamCategories.Add(new ExamCategory
                    {
                        Name = $"{exam.Title} Category",
                        ExamId = exam.ExamId
                    });
                }
                await context.SaveChangesAsync();
            }

            // ==================== Subjects ====================
            if (!context.Subjects.Any())
            {
                foreach (var exam in context.Exams.ToList())
                {
                    context.Subjects.Add(new Subject
                    {
                        Name = $"{exam.Title} Subject",
                        ExamId = exam.ExamId
                    });
                }
                await context.SaveChangesAsync();
            }

            // ==================== Topics ====================
            if (!context.Topics.Any())
            {
                foreach (var subject in context.Subjects.ToList())
                {
                    context.Topics.Add(new Topic
                    {
                        Name = $"{subject.Name} Topic",
                        SubjectId = subject.SubjectId
                    });
                }
                await context.SaveChangesAsync();
            }

            // ==================== Questions & Options ====================
            if (!context.Questions.Any())
            {
                foreach (var topic in context.Topics.ToList())
                {
                    var question = new Question
                    {
                        Text = $"Sample question for {topic.Name}",
                        TopicId = topic.Id
                    };
                    context.Questions.Add(question);
                    await context.SaveChangesAsync();

                    context.Options.AddRange(new List<Option>
                    {
                        new Option { Text = "Option A", QuestionId = question.QuestionId, IsCorrect = false },
                        new Option { Text = "Option B", QuestionId = question.QuestionId, IsCorrect = true },
                        new Option { Text = "Option C", QuestionId = question.QuestionId, IsCorrect = false },
                        new Option { Text = "Option D", QuestionId = question.QuestionId, IsCorrect = false }
                    });
                    await context.SaveChangesAsync();
                }
            }

            // ==================== User Progress ====================
            if (!context.UserProgress.Any())
            {
                var students = await userManager.GetUsersInRoleAsync("Student");
                var topics = context.Topics.ToList();

                foreach (var student in students)
                {
                    foreach (var topic in topics)
                    {
                        context.UserProgress.Add(new UserProgress
                        {
                            UserId = student.Id,
                            TopicId = topic.Id,
                            ProgressPercent = 0,
                            LastUpdated = DateTime.UtcNow
                        });
                    }
                }
                await context.SaveChangesAsync();
            }

            // ==================== Notes ====================
            if (!context.Notes.Any())
            {
                var students = await userManager.GetUsersInRoleAsync("Student");
                foreach (var student in students)
                {
                    context.Notes.Add(new Note
                    {
                        UserId = student.Id,
                        Title = "Sample Note",
                        Content = "This is a sample note.",
                        CreatedAt = DateTime.UtcNow
                    });
                }
                await context.SaveChangesAsync();
            }

            // ==================== Bookmarks ====================
            if (!context.Bookmarks.Any())
            {
                var students = await userManager.GetUsersInRoleAsync("Student");
                foreach (var student in students)
                {
                    context.Bookmarks.Add(new Bookmark
                    {
                        UserId = student.Id,
                        Title = "Sample Bookmark",
                        Url = "https://example.com",
                        CreatedAt = DateTime.UtcNow
                    });
                }
                await context.SaveChangesAsync();
            }

            // ==================== Exam Results ====================
            if (!context.ExamResults.Any())
            {
                var students = await userManager.GetUsersInRoleAsync("Student");
                foreach (var student in students)
                {
                    foreach (var exam in context.Exams.ToList())
                    {
                        context.ExamResults.Add(new ExamResult
                        {
                            UserId = student.Id,
                            ExamId = exam.ExamId,
                            Score = rand.Next(50, 100),
                            TakenAt = DateTime.UtcNow
                        });
                    }
                }
                await context.SaveChangesAsync();
            }

           // ==================== Blog Posts ====================
if (!context.BlogPosts.Any() && adminUser != null)
{
    var blogPosts = new List<BlogPost>
    {
        new BlogPost
        {
            Title = "Welcome to ExamDynamics",
            Content = "This is the first blog post!",
            AuthorId = adminUser.Id, // ✅ adminUser.Id is already a string
            PublishedAt = DateTime.UtcNow,
            IsPublished = true
        },
        new BlogPost
        {
            Title = "Smart Study Planner",
            Content = @"Smart Study Planner: Your Personalized Path to Efficient Learning

In the fast-paced world of education, managing study time effectively is crucial. A Smart Study Planner leverages technology to help students organize, prioritize, and optimize their learning schedule, ensuring better productivity and academic success.

What is a Smart Study Planner?

A Smart Study Planner is a digital tool or application designed to plan study sessions intelligently. Unlike traditional planners, it uses algorithms, reminders, and analytics to create a personalized study plan based on a student’s goals, deadlines, strengths, and weaknesses.

How a Smart Study Planner Works

Input Goals & Subjects: The student enters subjects, topics, exams, and deadlines into the system.

Analyze Study Patterns: The planner tracks study habits, time spent, and productivity levels.

Generate Optimized Schedule: Using smart algorithms, it creates a study timetable that balances workload, breaks, and priority topics.

Adaptive Adjustments: As the student progresses, the planner adapts the schedule, focusing on weaker areas and updating timelines.

Reminders & Notifications: The planner sends timely reminders to keep the student on track and maintain consistency.

Benefits of a Smart Study Planner

Efficient Time Management: Helps students allocate time wisely across subjects.

Personalized Learning: Adapts study sessions to the student’s strengths and weaknesses.

Increased Productivity: Reduces procrastination by breaking study tasks into manageable chunks.

Progress Tracking: Provides insights into study patterns and areas needing improvement.

Stress Reduction: Reduces last-minute cramming and improves confidence before exams.

Applications

School & College Students: Helps manage coursework, exams, and assignments efficiently.

Competitive Exam Preparation: Optimizes preparation schedules for exams like SAT, GRE, or competitive job exams.

Professional Learning: Assists working professionals in planning study sessions for certifications and skill development.

Future of Smart Study Planners

With AI and machine learning integration, smart planners will soon predict optimal learning times, suggest adaptive learning content, and even simulate exam scenarios for better preparation. They are set to become a must-have tool for every learner striving for efficiency and success.

✅ About Adding Images

As with the previous blog:

Copy-pasting images may not always display correctly.

Best practice: Download the images you want and upload them to your site. Then embed them using <img> tags or your CMS image tool.

This ensures images are always visible and load faster for users.",
            AuthorId = adminUser.Id, // ✅ string
            PublishedAt = DateTime.UtcNow,
            IsPublished = true
        }
    };

    await context.BlogPosts.AddRangeAsync(blogPosts);
    await context.SaveChangesAsync();
}


            // ==================== Subscriptions ====================
            if (!context.Subscriptions.Any())
            {
                context.Subscriptions.AddRange(new List<Subscription>
                {
                    new Subscription { Name = "Monthly", Price = 9.99m, DurationInDays = 30 },
                    new Subscription { Name = "Yearly", Price = 99.99m, DurationInDays = 365 }
                });
                await context.SaveChangesAsync();
            }

            // ==================== Study Materials ====================
            if (!context.StudyMaterials.Any())
            {
                foreach (var topic in context.Topics.ToList())
                {
                    context.StudyMaterials.Add(new StudyMaterial
                    {
                        Title = $"{topic.Name} Study Material",
                        Content = "https://example.com/material.pdf",
                        TopicId = topic.Id
                    });
                }
                await context.SaveChangesAsync();
            }

            // ==================== AI Sessions & Messages ====================
            if (!context.AiSessions.Any())
            {
                var student = await userManager.FindByEmailAsync("student@example.com");
                if (student != null)
                {
                    var session = new AiSession
                    {
                        UserId = student.Id,
                        StartedAt = DateTime.UtcNow
                    };
                    context.AiSessions.Add(session);
                    await context.SaveChangesAsync();

                    context.AiMessages.AddRange(new List<AiMessage>
                    {
                        new AiMessage { AiSessionId = session.AiSessionId, Content = "Hello AI!", IsRead = true, SentAt = DateTime.UtcNow },
                        new AiMessage { AiSessionId = session.AiSessionId, Content = "Hello! How can I help you?", IsRead = false, SentAt = DateTime.UtcNow }
                    });
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
