using Microsoft.AspNetCore.SignalR;

namespace Server.SignalR.Hubs
{
    public class HubA : Hub
    {
        public async Task EnviarMensagem(string mensagem)
            => await Clients.All.SendAsync("ReceberMensagem", mensagem, cancellationToken: new CancellationToken());
    }
}
