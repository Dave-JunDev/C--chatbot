using Microsoft.Extensions.AI;

namespace C__chatbot.DTO;

public class ChatDto
{
    public ChatRole Role { get; set; } = ChatRole.User;
    public string? Content { get; set; }

    public ChatDto(ChatRole role, string? content)
    {
        Role = role;
        Content = content;
    }
    public ChatDto()
    {
        
    }
}