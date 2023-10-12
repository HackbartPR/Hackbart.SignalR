namespace Server.SignalR.Hubs.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IChatMiddlewareHub
    {
        /// <summary>
        /// Cliente\Servidor envia mensagem para todos conectados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendMessageToAll(string sender, string message);

        /// <summary>
        /// Cliente\Servidor envia mensagem para um grupo específico
        /// </summary>
        /// <param name="group"></param>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendMessageToGroup(string group, string sender, string message);
    }
}
