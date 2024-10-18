using Microsoft.Extensions.Options;
using Models;
using MongoDB.Driver;

namespace Context;

public class MongoContext
{
    private readonly IMongoCollection<Chat> _chatCollection;
    public MongoContext(IOptions<MongoDBSettings> mongoDBSettings, IOptions<Collections> collections)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionString);
        var database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _chatCollection = database.GetCollection<Chat>(collections.Value.Chat);
    }

    public IMongoCollection<Chat> GetChatCollection() => _chatCollection;
}