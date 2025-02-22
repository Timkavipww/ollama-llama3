using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = Host.CreateApplicationBuilder();

builder.Services.AddChatClient(new OllamaChatClient(new Uri("http://localhost:11434"), "llama3"));

var app = builder.Build();

var chatClient = app.Services.GetRequiredService<IChatClient>();

var chatHistory = new List<ChatMessage>();

while(true)
{

    Console.WriteLine("Ваш запрос:");
    var userPrompt = Console.ReadLine();

    if(userPrompt is null)
        return;
    
    chatHistory.Add(new ChatMessage(ChatRole.User, userPrompt));

    Console.WriteLine("Ответ ИИ:");
    var chatresponse = "";
    await foreach(var item  in chatClient.GetStreamingResponseAsync(chatHistory))
    {
        Console.Write(item.Text);
        chatresponse += item.Text;
    }
    chatHistory.Add(new ChatMessage(ChatRole.User, chatresponse));
    Console.WriteLine();
}

