namespace DTO;

public class RequestChatbotDTO
{
    public string? Question { get; set; }
    public float? Temperature { get; set; }
    public float? TopP { get; set; }
    public int? MaxOutputTokens { get; set; }
}