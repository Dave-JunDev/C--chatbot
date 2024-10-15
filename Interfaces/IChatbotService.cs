using DTO;

namespace Interfaces;

public interface IChatbotService
{
    Task<ResponseChatbotDTO> Answer(RequestChatbotDTO question);
}