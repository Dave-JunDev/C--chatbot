using C__chatbot.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace C__chatbot.Context;

public class MongoContext
{
    private readonly IMongoCollection<Chat> _chatCollection;
    public MongoContext(IOptions<MongoDbSettings> mongoDBSettings, IOptions<Collections> collections)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionString);
        var database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _chatCollection = database.GetCollection<Chat>(collections.Value.Chat);
    }

    public IMongoCollection<Chat> GetChatCollection() => _chatCollection;
}