namespace Server.SignalR.Hubs.Abstractions
{
    /// <summary>
    /// Tipagem do Hub para métodos dos clientes
    /// </summary>
    public interface IChatClient
    {
        /// <summary>
        /// Cliente recebe mensagens de um determinado grupo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task ReceiveMessage(string sender, string message, CancellationToken cancellationToken = new());

        /// <summary>
        /// Cliente entra em um grupo específico para ouvir e enviar mensagens
        /// </summary>
        /// <param name="group"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task AddToGroup(string group, CancellationToken cancellationToken = new());

        /// <summary>
        /// Cliente sai de um grupo específico
        /// </summary>
        /// <param name="group"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task RemoveFromGroup(string group, CancellationToken cancellationToken = new());
    }
}
