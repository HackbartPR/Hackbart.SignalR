namespace Server.SignalR.Hubs.Abstractions
{
    /// <summary>
    /// Define o nome dos métodos de envio de mensagens
    /// </summary>
    public interface IChatServer
    {
        /// <summary>
        /// Cliente\Servidor envia mensagem para todos conectados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendMessageToAll(string sender, string message);

        /// <summary>
        /// Cliente\Servidor envia mensagem ou notificação para ele mesmo.
        /// Util em casos de notificações de conclusao de algum processo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendMessageToCaller(string sender, string message);

        /// <summary>
        /// Cliente\Servidor envia mensagem para um grupo específico
        /// </summary>
        /// <param name="group"></param>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendMessageToGroup(string group, string sender, string message);

        /// <summary>
        /// Cliente entra em um grupo\canal de comunicação específico
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public Task AddToGroup(string group);

        /// <summary>
        /// Cliente sai em um grupo\canal de comunicação específico
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public Task RemoveFromGroup(string group);
    }
}
