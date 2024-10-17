using Microsoft.Extensions.AI;

namespace DTO;

public class ResponseChatbotDTO
{
    public IList<ChatDTO>? Chat { get; set; }
    public int? InputTokenCount { get; set;}
    public int? OutputTokenCount { get; set; }
    public int? TotalTokenCount => InputTokenCount + OutputTokenCount;

    public ResponseChatbotDTO(IList<ChatDTO>? Message, int? InputTokenCount, int? OutputTokenCount)
    {
        this.Chat = Message;
        this.InputTokenCount = InputTokenCount;
        this.OutputTokenCount = OutputTokenCount;
    }
    public ResponseChatbotDTO()
    {
        
    }

    public void AddMessage(ChatRole role, string message)
    {
        if (Chat == null)
            Chat = new List<ChatDTO>();

        Chat.Add(new(role, message));
    }
}