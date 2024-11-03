using C__chatbot.Context;
using C__chatbot.Interfaces;
using C__chatbot.Models;
using C__chatbot.Services;

var builder = WebApplication.CreateBuilder(args);

// context
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.Configure<OllamaModel>(builder.Configuration.GetSection("Ollama"));
builder.Services.Configure<Collections>(builder.Configuration.GetSection("Collections"));
builder.Services.AddSingleton<MongoContext>();

// Add services to the container.
builder.Services.AddScoped<IChatbotService, ChatbotService>();
builder.Services.AddScoped<IChatService, ChatService>();
builder.Services.AddScoped<ICommonService, CommonService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();
app.MapControllers();

app.Run();
