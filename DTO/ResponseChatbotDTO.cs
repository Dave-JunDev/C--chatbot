namespace DTO;

public class ResponseChatbotDTO
{
    public string? Message { get; set; }
    public int? InputTokenCount { get; set;}
    public int? OutputTokenCount { get; set; }
    public int? TotalTokenCount => InputTokenCount + OutputTokenCount;

    public ResponseChatbotDTO(string? Message, int? InputTokenCount, int? OutputTokenCount)
    {
        this.Message = Message;
        this.InputTokenCount = InputTokenCount;
        this.OutputTokenCount = OutputTokenCount;
    }
    public ResponseChatbotDTO()
    {
        
    }

}