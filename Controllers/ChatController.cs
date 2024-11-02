using C__chatbot.Interfaces;
using C__chatbot.Models;
using Microsoft.AspNetCore.Mvc;

namespace C__chatbot.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatController(IChatService chatService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAllChat()
    {
        var chats = await chatService.GetAllChat();
        return Ok(chats);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetChatById(string id)
    {
        var chat = await chatService.GetChatById(id);
        return Ok(chat);
    }

    [HttpPost]
    public async Task<IActionResult> CreateChat([FromBody] Chat chat)
    {
        await chatService.CreateChat(chat);
        return Ok(chat);
    }    

    [HttpPost("massive")]
    public async Task<IActionResult> CreateMassiveChat([FromBody] List<Chat> chats)
    {
        await chatService.CreateMassiveChat(chats);
        return Ok(chats);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateChat([FromBody] Chat chat, string id)
    {
        await chatService.UpdateChat(chat, id);
        return Ok(chat);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteChat(string id)
    {
        await chatService.DeleteChat(id);
        return Ok();
    }
}