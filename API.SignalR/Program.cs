using API.SignalR.Worker;
using Server.SignalR;
using Server.SignalR.Domain.Configurations;
using Server.SignalR.Hubs;
using Server.SignalR.Hubs.Abstractions;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
Settings.Configure(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterSignalR();
builder.Services.AddTransient<IChatMiddlewareHub, MiddlewareHub>();
builder.Services.AddHostedService<Updater>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Registrando os Hubs
app.MapHub<ChatHub>("/hubs/chathub");

app.Run();