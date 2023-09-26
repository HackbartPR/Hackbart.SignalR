using ClientC.SignalR.Service.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ClientC.Worker
{
    /// <summary>
    /// Será responsável por 'hospedar' o Hub Cliente.
    /// Por não estar em uma aplicação ASP.Net a solução será criar um Hosting utilizando WorkerServices
    /// </summary>
    public class HubServiceWorker : BackgroundService
    {
        private readonly IServiceProvider _services;
        private readonly ILogger<HubServiceWorker> _logger;

        public HubServiceWorker(IServiceProvider services, ILogger<HubServiceWorker> logger)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _logger.LogInformation("Aplicação HubServiceWorker Ligada");

                using (var scope = _services.CreateScope())
                {
                    IHubService hubService = scope.ServiceProvider.GetRequiredService<IHubService>();

                    Task listeningTask = Task.Run(() => hubService.Listening(stoppingToken), stoppingToken);
                    Task enviarTask = Task.Run(() => Chat.EnviarMensagem(hubService, stoppingToken), stoppingToken);

                    await Task.WhenAll(listeningTask, enviarTask);
                }

                _logger.LogInformation("Aplicação HubServiceWorker Desligada");
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
