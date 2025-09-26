
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using ExamDynamicsAPI.Core.DTOs.ChatDTOs;
using ExamDynamicsAPI.Core.Interfaces.Services;
using ExamDynamicsAPI.Infrastructure.Data;
using ExamDynamicsAPI.Models;

namespace ExamDynamicsAPI.Services
{
    public class ChatService : IChatService
    {
        private readonly HttpClient _httpClient;
        private readonly string _openAiKey;
        private readonly ExamDynamicsDbContext _context;

        public ChatService(IHttpClientFactory httpClientFactory, IConfiguration configuration, ExamDynamicsDbContext context)
        {
            _httpClient = httpClientFactory.CreateClient();
            _openAiKey = configuration["OpenAI:ApiKey"]!;
            _context = context;
        }

        public async Task<ChatResponseDto> GetAnswerAsync(ChatRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Question))
            {
                return new ChatResponseDto { Answer = "Please provide a question." };
            }

            var messages = new[]
            {
                new ChatMessage { Role = "user", Content = request.Question }
            };

            var payload = new
            {
                model = "gpt-3.5-turbo",
                messages = messages
            };

            var httpContent = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _openAiKey);

            ChatResponseDto answerDto = null!;
            int retries = 3;

            for (int attempt = 1; attempt <= retries; attempt++)
            {
                try
                {
                    var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", httpContent);

                    if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                    {
                        if (attempt == retries)
                        {
                            answerDto = new ChatResponseDto
                            {
                                Answer = "OpenAI API rate limit exceeded. Please try again after a few seconds."
                            };
                            break;
                        }
                        await Task.Delay(2000); // wait 2 seconds before retry
                        continue;
                    }

                    if (!response.IsSuccessStatusCode)
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        answerDto = new ChatResponseDto
                        {
                            Answer = $"OpenAI API error: {response.StatusCode} - {errorContent}"
                        };
                        break;
                    }

                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    using var doc = JsonDocument.Parse(jsonResponse);

                    string? answer = doc.RootElement
                                        .GetProperty("choices")[0]
                                        .GetProperty("message")
                                        .GetProperty("content")
                                        .GetString();

                    answerDto = new ChatResponseDto
                    {
                        Answer = answer ?? "No answer received."
                    };

                    break; // Success, exit retry loop
                }
                catch (Exception ex)
                {
                    if (attempt == retries)
                    {
                        answerDto = new ChatResponseDto
                        {
                            Answer = $"Unable to get response from OpenAI: {ex.Message}"
                        };
                    }
                    else
                    {
                        await Task.Delay(1000); // retry delay
                    }
                }
            }

            // Save chat history if answer is available
            // if (answerDto != null)
            // {
            //     var chatHistory = new ChatHistory
            //     {
            //         Question = request.Question,
            //         Answer = answerDto.Answer
            //     };
            //     // _context.ChatHistories.Add(chatHistory);
            //     await _context.SaveChangesAsync();
            // }

            return answerDto!;
        }
    }
}
