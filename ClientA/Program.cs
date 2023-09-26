using ClientA.Domain.Configurations;
using ClientA.SignalR.Provider;
using ClientA.SignalR.Service;
using ClientA.SignalR.Service.Abstraction;
using ClientA.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//var builder = new ConfigurationBuilder();
//builder.SetBasePath(Directory.GetCurrentDirectory());
//builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

//IConfiguration config = builder.Build();
//Settings.Configure(config);

var builder = new HostBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                    var configuration = config.Build();
                    Settings.Configure(configuration);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<IHubService, HubService>();
                    services.AddTransient<HubServiceProvider>();
                    services.AddHostedService<HubServiceWorker>();
                });

await builder.RunConsoleAsync();




