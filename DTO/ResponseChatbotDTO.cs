using Microsoft.Extensions.AI;

namespace DTO;

public class ResponseChatbotDTO
{
    public string? ConversationId { get; set; }
    public IList<ChatDTO>? Conversation { get; set; }
    public int? InputTokenCount { get; set;}
    public int? OutputTokenCount { get; set; }
    public int? TotalTokenCount { get; set; }

    public ResponseChatbotDTO(string? conversationId, IList<ChatDTO>? message, int? inputTokenCount, int? outputTokenCount, int? totalTokenCount)
    {
        ConversationId = conversationId;
        Conversation = message;
        InputTokenCount = inputTokenCount;
        OutputTokenCount = outputTokenCount;
        TotalTokenCount = totalTokenCount;
    }
    public ResponseChatbotDTO()
    {
        
    }

    public void AddMessage(ChatRole role, string message)
    {
        if (Conversation == null)
            Conversation = new List<ChatDTO>();

        Conversation.Add(new(role, message));
    }
}