using System.Text.Json;
using DTO;
using Interfaces;
using Microsoft.Extensions.AI;

namespace Services;

public class ChatbotService : IChatbotService
{
    private readonly IChatClient _chatClient;
    private readonly ILogger<ChatbotService> _logger;
    public ChatbotService(ILogger<ChatbotService> logger)
    {
        if (_chatClient == null)
        {
            Uri uri = new Uri("http://localhost:11434");
            string model = "gemma2:latest";
            _chatClient = new OllamaChatClient(uri, model);
        }
        _logger = logger;
    }

    public async Task<ResponseChatbotDTO> Chat(RequestChatbotDTO question)
    {
        ChatOptions options = new ()
        {
            Temperature = question.Temperature ?? 0.5f,
            MaxOutputTokens = question.MaxOutputTokens ?? 1000,
            TopP = question.TopP ?? 0.5f
        };

        IList<ChatMessage> chatMessages = TransformToChatMessage(question);
        ChatCompletion response = await _chatClient.CompleteAsync(chatMessages!, options);
        _logger.LogInformation("This is the all properties of a response Model" + JsonSerializer.Serialize(response));
        
        ResponseChatbotDTO responseChatbotDTO = new(
            question.Chat,
            response.Usage!.InputTokenCount,
            response.Usage!.OutputTokenCount
        );
        responseChatbotDTO.AddMessage(ChatRole.Assistant, response.Message.ToString());

        return responseChatbotDTO;
    }

    private IList<ChatMessage> TransformToChatMessage(RequestChatbotDTO question)
    {
        IList<ChatMessage> chatMessages = new List<ChatMessage>();

        chatMessages = question.Chat!.Select(chat =>
        {
            ChatMessage chatMessage = new ChatMessage(chat.Role, chat.Content);
            return chatMessage;
        }).ToList();

        return chatMessages;
    }
}