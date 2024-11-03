using System.Text.Json;
using C__chatbot.DTO;
using C__chatbot.Interfaces;
using C__chatbot.Models;
using DTO;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Options;

namespace C__chatbot.Services;

public class ChatbotService : IChatbotService
{
    private readonly OllamaChatClient _client;
    private readonly IChatService _chatService;
    private readonly ILogger<ChatbotService> _logger;
    public ChatbotService(IChatService chatService, ILogger<ChatbotService> logger, IOptions<OllamaModel> chatClient)
    {
        var ollamaModel = new OllamaModel(chatClient.Value.Url!,chatClient.Value.Model!);
        _client = ollamaModel.InstanceModel();
        _chatService = chatService;
        _logger = logger;
    }

    public async Task<ResponseChatbotDto> Chat(RequestChatbotDto question)
    {
        ChatOptions options = new ()
        {
            Temperature = question.Temperature,
            MaxOutputTokens = question.MaxOutputTokens,
            TopP = question.TopP
        };

        var chatMessages = TransformToChatMessage(question);
        var response = await _client.CompleteAsync(chatMessages!, options);
        _logger.LogInformation("This is the all properties of a response Model" + JsonSerializer.Serialize(response));
        
        ResponseChatbotDto responseChatbotDto = new(
            question.ConversationId,
            question.Conversation,
            response.Usage!.InputTokenCount,
            response.Usage!.OutputTokenCount,
            response.Usage.TotalTokenCount
        );
        responseChatbotDto.AddMessage(ChatRole.Assistant, response.Message.ToString());
        responseChatbotDto.ConversationId = await CreateOrUpdateChat(responseChatbotDto, options);

        return responseChatbotDto;
    }

    private async Task<string> CreateOrUpdateChat(ResponseChatbotDto response, ChatOptions options)
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

    private IList<ChatMessage> TransformToChatMessage(RequestChatbotDto question)
    {
        IList<ChatMessage> chatMessages;

        chatMessages = question.Conversation!.Select(chat =>
        {
            ChatMessage chatMessage = new(chat.Role, chat.Content);
            return chatMessage;
        }).ToList();

        return chatMessages;
    }
}