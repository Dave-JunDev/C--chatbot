using Microsoft.Extensions.AI;

namespace DTO;

public class RequestChatbotDTO
{
    public IList<ChatDTO>? Chat { get; set; }
    public float? Temperature { get; set; }
    public float? TopP { get; set; }
    public int? MaxOutputTokens { get; set; }
}