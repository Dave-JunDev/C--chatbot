using Microsoft.Extensions.AI;

namespace C__chatbot.Models;

public class OllamaModel
{
    public string? Url { get; set; }
    public string? Model { get; set; }
    private OllamaChatClient? Client { get; set; }

    public OllamaChatClient InstanceModel()
    {
        if (Client == null)
        {
            Client = new OllamaChatClient(new Uri(Url!), Model!);
        }
        
        return Client;
    }

    public OllamaModel()
    {
        
    }

    public OllamaModel(string url, string model)
    {
        Url = url;
        Model = model;
    }
}