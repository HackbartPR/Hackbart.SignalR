using Microsoft.AspNetCore.SignalR.Client;

namespace ClientB
{
    /// <summary>
    /// Cliente A para receber e enviar mensagens via SignalR
    /// </summary>
    public sealed class Client : IAsyncDisposable
    {
        private readonly HubConnection _connection;
        private readonly string _clientName;

        /// <summary>
        /// Construtor
        /// </summary>
        public Client()
        {
            _clientName = "Cliente B";
            _connection = new HubConnectionBuilder().WithUrl("https://localhost:7056/hubs/huba").Build();
        }

        /// <summary>
        /// Inicia o processo de receber e enviar mensagens
        /// </summary>
        /// <returns></returns>
        public async Task Start()
        {
            try
            {
                await _connection.StartAsync();
                Console.WriteLine("Conexão Estabelecida.\n");

                var responseReceived = new TaskCompletionSource<bool>();

                _connection.On<string>("ReceberMensagem", ShowAndSendMessage);

                await _connection.InvokeAsync("EnviarMensagem", $"{_clientName}: *");

                await responseReceived.Task;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally { await _connection.StopAsync(); }
        }

        /// <summary>
        /// Mostra e Responde a mensagem recebida
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private async Task ShowAndSendMessage(string message)
        {
            Console.WriteLine(message);
            await Task.Delay(2000);

            string response = message.Split(": ")[1] + "*";
            await _connection.InvokeAsync("EnviarMensagem", $"{_clientName}: {response}");
        }

        /// <summary>
        /// Fecha todos os processos relacionados a conexão
        /// </summary>
        /// <returns></returns>
        public async ValueTask DisposeAsync()
            => await _connection.DisposeAsync();
    }
}
