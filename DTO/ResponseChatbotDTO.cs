using Microsoft.Extensions.AI;

namespace C__chatbot.DTO;

public class ResponseChatbotDto
{
    public string? ConversationId { get; set; }
    public IList<ChatDto>? Conversation { get; set; }
    public int? InputTokenCount { get; set;}
    public int? OutputTokenCount { get; set; }
    public int? TotalTokenCount { get; set; }

    public ResponseChatbotDto(string? conversationId, IList<ChatDto>? message, int? inputTokenCount, int? outputTokenCount, int? totalTokenCount)
    {
        ConversationId = conversationId;
        Conversation = message;
        InputTokenCount = inputTokenCount;
        OutputTokenCount = outputTokenCount;
        TotalTokenCount = totalTokenCount;
    }
    public ResponseChatbotDto()
    {
        
    }

    public void AddMessage(ChatRole role, string message)
    {
        if (Conversation == null)
            Conversation = new List<ChatDto>();

        Conversation.Add(new(role, message));
    }
}