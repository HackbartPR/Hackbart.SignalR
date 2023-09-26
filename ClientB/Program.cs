using ClientB.Domain.Configurations;
using ClientB.SignalR.Provider;
using ClientB.SignalR.Service;
using ClientB.SignalR.Service.Abstraction;
using ClientB.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
