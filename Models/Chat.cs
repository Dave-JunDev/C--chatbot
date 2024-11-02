using C__chatbot.DTO;
using DTO;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace C__chatbot.Models;

public class Chat
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; } = ObjectId.GenerateNewId().ToString();
    public IList<ChatDto>? Conversation { get; set; }
    public float? Temperature { get; set; } = 0.5f;
    public float? TopP { get; set; } = 0.5f;
    public int? MaxOutputTokens { get; set; } = 1000;

    public Chat(string? id, IList<ChatDto>? conversation, float? temperature, float? topP, int? maxOutputTokens)
    {
        Id = id;
        Conversation = conversation;
        Temperature = temperature;
        TopP = topP;
        MaxOutputTokens = maxOutputTokens;
    }
    public Chat(IList<ChatDto>? conversation, float? temperature, float? topP, int? maxOutputTokens)
    {
        Conversation = conversation;
        Temperature = temperature;
        TopP = topP;
        MaxOutputTokens = maxOutputTokens;
    }

    public Chat(IList<ChatDto> conversation)
    {
        Conversation = conversation;
    }
    public Chat() { }

}