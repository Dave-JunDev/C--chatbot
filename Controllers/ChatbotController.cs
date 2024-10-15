using DTO;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace controller;

[Route("[controller]")]
[ApiController]
public class ChatbotController : Controller
{
    private readonly IChatbotService _chatbotService;
    public ChatbotController(IChatbotService chatbotService)
    {
        _chatbotService = chatbotService;
    }

    [HttpPost]
    public async Task<IActionResult> Question(RequestChatbotDTO question)
    {
        ResponseChatbotDTO response = await _chatbotService.Answer(question);

        if (response.Message!.Length > 0)
            return Ok(response);

        return BadRequest("Error to response");
    }
}