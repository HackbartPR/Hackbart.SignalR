using Microsoft.AspNetCore.SignalR;
using Server.SignalR.Hubs.Abstractions;

namespace Server.SignalR.Hubs
{
    /// <summary>
    /// Hub
    /// </summary>
    public class ChatHub : Hub<IChatClient>
    {
        /// <summary>
        /// Cliente\Servidor envia mensagem para todos conectados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(string sender, string message)
            => await Clients.All.ReceiveMessage(sender, message, new CancellationToken());

        /// <summary>
        /// Cliente\Servidor envia mensagem ou notificação para ele mesmo.
        /// Util em casos de notificações de conclusao de algum processo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessageToCaller(string sender, string message)
            => await Clients.Caller.ReceiveMessage(sender, message, new CancellationToken());

        //TODO: CRIAR METODO PARA ENVIAR PARA UM CLIENTE EM ESPECÍFICO

        /// <summary>
        /// Cliente\Servidor envia mensagem para um grupo específico
        /// </summary>
        /// <param name="group"></param>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessageToGroup(string group, string sender, string message)
            => await Clients.Group(group).ReceiveMessage(sender, message, new CancellationToken());
    }
}
