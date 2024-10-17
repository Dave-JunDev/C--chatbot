using Microsoft.Extensions.AI;

namespace DTO;

public class ChatDTO
{
    public ChatRole Role { get; set; } = ChatRole.User;
    public string? Content { get; set; }

    public ChatDTO(ChatRole role, string? content)
    {
        Role = role;
        Content = content;
    }
    public ChatDTO()
    {
        
    }
}