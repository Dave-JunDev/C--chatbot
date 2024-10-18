using Context;
using Interfaces;
using Models;
using MongoDB.Driver;

namespace Services;

public class ChatService : IChatService
{
    private readonly ICommonService _commonService;
    private readonly MongoContext _mongoContext;
    private readonly IMongoCollection<Chat> _chatCollection;

    public ChatService(ICommonService commonService, MongoContext mongoContext)
    {
        _commonService = commonService;
        _mongoContext = mongoContext;
        _chatCollection = _mongoContext.GetChatCollection();
    }

    public async Task<Chat> GetChatById(string id)
    {
        return await _commonService.GetItemByIdAsync<Chat>(_chatCollection, id);
    }

    public async Task<List<Chat>> GetAllChat()
    {
        return await _commonService.GetAll<Chat>(_chatCollection);
    }

    public async Task CreateChat(Chat chat)
    {
        await _commonService.CreateItemAsync<Chat>(_chatCollection, chat);
    }

    public async Task CreateMassiveChat(List<Chat> chats)
    {
        await _commonService.CreateMassiveAsync<Chat>(_chatCollection, chats);
    }

    public async Task UpdateChat(Chat chat, string id)
    {
        await _commonService.UpdateItemAsync<Chat>(_chatCollection, chat, id);
    }

    public async Task DeleteChat(string id)
    {
        await _chatCollection.DeleteOneAsync($"{{ _id: ObjectId('{id}') }}");
    }

}