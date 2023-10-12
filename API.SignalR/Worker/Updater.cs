using Server.SignalR.Hubs.Abstractions;

namespace API.SignalR.Worker
{
    /// <summary>
    /// Representando algum processo em segundo plano
    /// </summary>
    public class Updater : BackgroundService
    {
        private readonly IChatMiddlewareHub _middleHub;

        public Updater(IChatMiddlewareHub middleHub)
            => _middleHub = middleHub ?? throw new ArgumentNullException(nameof(middleHub));

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //Faz algum tipo de processo em segundo plano
            await Task.Delay(3000);

            await _middleHub.SendMessageToAll("Servidor", "Servidor mandando mensagem para todos");

            await Task.Delay(3000);

            await _middleHub.SendMessageToAll("Servidor", "Servidor mandando mensagem para um grupo");
        }
    }
}
