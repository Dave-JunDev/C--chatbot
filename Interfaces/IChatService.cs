using Models;

namespace Interfaces;

public interface IChatService
{
    Task<Chat> GetChatById(string id);
    Task<List<Chat>> GetAllChat();
    Task CreateChat(Chat chat);
    Task CreateMassiveChat(List<Chat> chats);
    Task UpdateChat(Chat chat, string id);
    Task DeleteChat(string id);
}