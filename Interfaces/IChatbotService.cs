using DTO;

namespace Interfaces;

public interface IChatbotService
{
    Task<ResponseChatbotDTO> Chat(RequestChatbotDTO question);
}