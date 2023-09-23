using ClientA;
using ClientA.Domain.Configurations;
using ClientA.SignalR;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory());
builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration config = builder.Build();
Settings.Configure(config);

Console.WriteLine("Cliente A");
await Task.Delay(3000);

await using (Client client = new())
{
    await client.Start();
}



