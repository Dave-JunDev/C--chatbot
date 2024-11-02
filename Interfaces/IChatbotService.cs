using C__chatbot.DTO;
using DTO;

namespace C__chatbot.Interfaces;

public interface IChatbotService
{
    Task<ResponseChatbotDto> Chat(RequestChatbotDto question);
}