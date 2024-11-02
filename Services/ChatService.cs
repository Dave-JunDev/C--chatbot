using C__chatbot.Context;
using C__chatbot.Interfaces;
using C__chatbot.Models;
using MongoDB.Driver;

namespace C__chatbot.Services;

public class ChatService(ICommonService commonService, MongoContext mongoContext) : IChatService
{
    private readonly IMongoCollection<Chat> _chatCollection = mongoContext.GetChatCollection();

    public async Task<Chat> GetChatById(string id) 
        => await commonService.GetItemByIdAsync<Chat>(_chatCollection, id);

    public async Task<List<Chat>> GetAllChat() 
        => await commonService.GetAll<Chat>(_chatCollection);

    public async Task CreateChat(Chat chat)
        => await commonService.CreateItemAsync<Chat>(_chatCollection, chat);

    public async Task CreateMassiveChat(List<Chat> chats)
        => await commonService.CreateMassiveAsync<Chat>(_chatCollection, chats);

    public async Task UpdateChat(Chat chat, string id)
        => await commonService.UpdateItemAsync<Chat>(_chatCollection, chat, id);
    

    public async Task DeleteChat(string id)
        => await _chatCollection.DeleteOneAsync($"{{ _id: ObjectId('{id}') }}");
}