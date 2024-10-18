using System.Security.Cryptography.X509Certificates;
using DTO;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models;

public class Chat
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; } = ObjectId.GenerateNewId().ToString();
    public IList<ChatDTO>? Conversation { get; set; }
    public float? Temperature { get; set; } = 0.5f;
    public float? TopP { get; set; } = 0.5f;
    public int? MaxOutputTokens { get; set; } = 1000;

    public Chat(string? id, IList<ChatDTO>? conversation, float? temperature, float? topP, int? maxOutputTokens)
    {
        Id = id;
        Conversation = conversation;
        Temperature = temperature;
        TopP = topP;
        MaxOutputTokens = maxOutputTokens;
    }
    public Chat(IList<ChatDTO>? conversation, float? temperature, float? topP, int? maxOutputTokens)
    {
        Conversation = conversation;
        Temperature = temperature;
        TopP = topP;
        MaxOutputTokens = maxOutputTokens;
    }

    public Chat(IList<ChatDTO> conversation)
    {
        Conversation = conversation;
    }
    public Chat() { }

}