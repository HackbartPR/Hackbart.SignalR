namespace ClientB.SignalR.Service.Abstraction
{
    public interface IHubService
    {
        /// <summary>
        /// Cliente envia mensagem para todo mundo
        /// </summary>
        /// <param name="message"></param>
        /// <param name="method">CHubMethods</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task ManageMessage(string message, string method, CancellationToken cancellationToken, string group = "");

        /// <summary>
        /// Cliente entra em um grupo específico
        /// </summary>
        /// <param name="group"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task AddToGroup(string group, CancellationToken cancellationToken);

        /// <summary>
        /// Cliente sai de um grupo específico
        /// </summary>
        /// <param name="group"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task RemoveFromGroup(string group, CancellationToken cancellationToken);

        /// <summary>
        /// Cliente fica esperando receber mensagem
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Listening(CancellationToken cancellationToken);
    }
}
