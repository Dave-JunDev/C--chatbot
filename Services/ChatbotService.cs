using System.Text.Json;
using DTO;
using Interfaces;
using Microsoft.Extensions.AI;
using Models;

namespace Services;

public class ChatbotService : IChatbotService
{
    private readonly OllamaChatClient _chatClient;
    private readonly IChatService _chatService;
    private readonly ILogger<ChatbotService> _logger;
    public ChatbotService(IChatService chatService, ILogger<ChatbotService> logger)
    {
        if (_chatClient == null)
        {
            Uri uri = new Uri("http://localhost:11434");
            string model = "gemma2:latest";
            _chatClient = new OllamaChatClient(uri, model);
        }
        _chatService = chatService;
        _logger = logger;
    }

    public async Task<ResponseChatbotDTO> Chat(RequestChatbotDTO question)
    {
        ChatOptions options = new ()
        {
            Temperature = question.Temperature,
            MaxOutputTokens = question.MaxOutputTokens,
            TopP = question.TopP
        };

        IList<ChatMessage> chatMessages = TransformToChatMessage(question);
        ChatCompletion response = await _chatClient.CompleteAsync(chatMessages!, options);
        _logger.LogInformation("This is the all properties of a response Model" + JsonSerializer.Serialize(response));
        
        ResponseChatbotDTO responseChatbotDTO = new(
            question.ConversationId,
            question.Conversation,
            response.Usage!.InputTokenCount,
            response.Usage!.OutputTokenCount,
            response.Usage.TotalTokenCount
        );
        responseChatbotDTO.AddMessage(ChatRole.Assistant, response.Message.ToString());
        responseChatbotDTO.ConversationId = await CreateOrUpdateChat(responseChatbotDTO, options);

        return responseChatbotDTO;
    }

    private async Task<String> CreateOrUpdateChat(ResponseChatbotDTO response, ChatOptions options)
    {
        Chat chat;
        if (response.ConversationId == null)
        {
            chat = new Chat(response.Conversation, options.Temperature, options.TopP, options.MaxOutputTokens);
            await _chatService.CreateChat(chat);
        }
        else
        {
            chat = new Chat(response.ConversationId, response.Conversation, options.Temperature, options.TopP, options.MaxOutputTokens);
            await _chatService.UpdateChat(chat, response.ConversationId);
        }

        return chat.Id!;
    }

    private IList<ChatMessage> TransformToChatMessage(RequestChatbotDTO question)
    {
        IList<ChatMessage> chatMessages = new List<ChatMessage>();

        chatMessages = question.Conversation!.Select(chat =>
        {
            ChatMessage chatMessage = new(chat.Role, chat.Content);
            return chatMessage;
        }).ToList();

        return chatMessages;
    }
}