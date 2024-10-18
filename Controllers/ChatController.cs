using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatController : Controller
{
    private readonly IChatService _chatService;
    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllChat()
    {
        var chats = await _chatService.GetAllChat();
        return Ok(chats);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetChatById(string id)
    {
        var chat = await _chatService.GetChatById(id);
        return Ok(chat);
    }

    [HttpPost]
    public async Task<IActionResult> CreateChat([FromBody] Chat chat)
    {
        await _chatService.CreateChat(chat);
        return Ok(chat);
    }    

    [HttpPost("massive")]
    public async Task<IActionResult> CreateMassiveChat([FromBody] List<Chat> chats)
    {
        await _chatService.CreateMassiveChat(chats);
        return Ok(chats);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateChat([FromBody] Chat chat, string id)
    {
        await _chatService.UpdateChat(chat, id);
        return Ok(chat);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteChat(string id)
    {
        await _chatService.DeleteChat(id);
        return Ok();
    }
}