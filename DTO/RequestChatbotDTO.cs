using Microsoft.Extensions.AI;

namespace DTO;

public class RequestChatbotDTO
{
    public string? ConversationId { get; set; }
    public IList<ChatDTO>? Conversation { get; set; }
    public float? Temperature { get; set; } = 0.5f;
    public float? TopP { get; set; } = 0.5f;
    public int? MaxOutputTokens { get; set; } = 1000;
}