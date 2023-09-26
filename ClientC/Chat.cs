using ClientC.SignalR.Service.Abstraction;

namespace ClientC
{
    /// <summary>
    /// Essa classe foi criada somente para organizar as mensagens que serão trocadas
    /// </summary>
    public static class Chat
    {
        //public static async Task EnviarMensagem(IHubService hubService, CancellationToken cancellationToken)
        //{
        //    Console.WriteLine("### Entrando no Grupo01 ###");
        //    await hubService.AddToGroup("Teste01", cancellationToken);

        //    await Task.Delay(24000, cancellationToken);            
        //    await hubService.ManageMessage("Certo, até mais!", "SendMessageToGroup", cancellationToken, "Teste01");

        //    Console.WriteLine("### Saindo do Grupo01 ###");
        //    await hubService.RemoveFromGroup("Teste01", cancellationToken);
        //}

        public static async Task EnviarMensagem(IHubService hubService, CancellationToken cancellationToken)
        {
            await hubService.AddToGroup("Teste01", cancellationToken);

            await Task.Delay(24000, cancellationToken);
            await hubService.ManageMessage("Certo, até mais!", "SendMessageToGroup", cancellationToken, "Teste01");

            Console.WriteLine("### Saindo do Grupo01 ###");
            await hubService.RemoveFromGroup("Teste01", cancellationToken);
        }
    }
}
