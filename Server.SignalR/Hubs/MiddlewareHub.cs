using Microsoft.AspNetCore.SignalR;
using Server.SignalR.Hubs.Abstractions;

namespace Server.SignalR.Hubs
{
    /// <summary>
    /// Serve para enviar mensagens para o Hub sem a necessidade de se conectar ao hub.
    /// </summary>
    public class MiddlewareHub : IChatMiddlewareHub
    {
        private readonly IHubContext<ChatHub, IChatClient> hubContext;

        public MiddlewareHub(IHubContext<ChatHub, IChatClient> hubContext)
            => this.hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));

        public async Task SendMessageToAll(string sender, string message)
            => await hubContext.Clients.All.ReceiveMessage(sender, message, new CancellationToken());

        public async Task SendMessageToGroup(string group, string sender, string message)
            => await hubContext.Clients.Group(group).ReceiveMessage(sender, message, new CancellationToken());
    }
}
