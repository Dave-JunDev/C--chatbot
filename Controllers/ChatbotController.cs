using C__chatbot.DTO;
using C__chatbot.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace C__chatbot.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatbotController(IChatbotService chatbotService) : Controller
{
    [HttpPost]
    public async Task<IActionResult> Question(RequestChatbotDto question)
    {
        var response = await chatbotService.Chat(question);

        if (response.Conversation!.Count > 0)
            return Ok(response);

        return BadRequest("Error to response");
    }
}