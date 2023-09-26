using ClientC.Domain.Configurations;
using ClientC.Domain.Constants;
using ClientC.SignalR.Provider;
using ClientC.SignalR.Service.Abstraction;
using Microsoft.AspNetCore.SignalR.Client;

namespace ClientC.SignalR.Service
{
    /// <summary>
    /// Provedor de acesso ao Hub
    /// </summary>
    public class HubService : IHubService, IAsyncDisposable
    {
        private readonly string _sender;
        private readonly HubServiceProvider _provider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public HubService(HubServiceProvider provider)
        {
            _sender = Settings.Application.ClientName;
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));

            CancellationToken cancellationToken = new(); 
            _provider.Connection.StartAsync(cancellationToken).Wait();
        }

        //Gerencia qual método deve utilizar para enviar a mensagem

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="method"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task ManageMessage(string message, string method, CancellationToken cancellationToken, string group = "")
        {
            try
            {
                if (message == string.Empty || method == string.Empty)
                    throw new Exception("Campos obrigatórios não preenchidos");

                switch (method)
                {
                    case CHubMethods.SEND_MESSAGE_TO_ALL:
                        await SendMessageToAll(message, cancellationToken);
                        break;
                    case CHubMethods.SEND_MESSAGE_TO_CALLER:
                        await SendMessageToCaller(message, cancellationToken);
                        break;
                    case CHubMethods.SEND_MESSAGE_TO_GROUP:
                        await SendMessageToGroup(group, message, cancellationToken);
                        break;
                }

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Envia mensagem para todos
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task SendMessageToAll(string message, CancellationToken cancellationToken)
            => await _provider.Connection.InvokeAsync(CHubMethods.SEND_MESSAGE_TO_ALL, _sender, message, cancellationToken);

        /// <summary>
        /// Envia mensagem para ele mesmo
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task SendMessageToCaller(string message, CancellationToken cancellationToken)
            => await _provider.Connection.InvokeAsync(CHubMethods.SEND_MESSAGE_TO_CALLER, _sender, message, cancellationToken);

        /// <summary>
        /// Envia mensagem para um grupo
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task SendMessageToGroup(string group, string message, CancellationToken cancellationToken)
        {
            if (group == string.Empty)
                throw new Exception("Campos obrigatórios não preenchidos");

            await _provider.Connection.InvokeAsync(CHubMethods.SEND_MESSAGE_TO_GROUP, group, _sender, message, cancellationToken);
        }

        /// <summary>
        /// Entra em um grupo específico
        /// </summary>
        /// <param name="group"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task AddToGroup(string group, CancellationToken cancellationToken)
        {
            try
            {
                if (group == string.Empty)
                    throw new Exception("Campos obrigatórios não preenchidos");

                await _provider.Connection.InvokeAsync(CHubMethods.ADD_TO_GROUP, group, cancellationToken);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Sai de um grupo específico
        /// </summary>
        /// <param name="group"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task RemoveFromGroup(string group, CancellationToken cancellationToken)
        {
            try
            {
                if (group == string.Empty)
                    throw new Exception("Campos obrigatórios não preenchidos");

                await _provider.Connection.InvokeAsync(CHubMethods.REMOVE_TO_GROUP, group, cancellationToken);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Método para ouvir as mensagens
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Listening(CancellationToken cancellationToken)
        {
            try
            {
                var responseReceived = new TaskCompletionSource<bool>();

                _provider.Connection.On<string, string>("ReceiveMessage", (sender, message) =>
                {
                    Console.WriteLine($"{sender}: {message}\n");
                });

                await responseReceived.Task;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Fecha todos os processos relacionados a conexão
        /// </summary>
        /// <returns></returns>
        public async ValueTask DisposeAsync()
            => await _provider.Connection.DisposeAsync();
    }
}
