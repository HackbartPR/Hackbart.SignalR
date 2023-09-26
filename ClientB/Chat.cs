using ClientB.SignalR.Service.Abstraction;

namespace ClientB
{
    /// <summary>
    /// Essa classe foi criada somente para organizar as mensagens que serão trocadas
    /// </summary>
    public static class Chat
    {
        public static async Task EnviarMensagem(IHubService hubService, CancellationToken cancellationToken)
        {
            await Task.Delay(2000, cancellationToken);
            Console.WriteLine("### Enviando Mensagem Para Todos ###");
            await hubService.ManageMessage("Olá ClienteA", "SendMessageToAll", cancellationToken);

            await Task.Delay(3000, cancellationToken);
            await hubService.ManageMessage("Tudo 100%", "SendMessageToAll", cancellationToken);

            await Task.Delay(3000, cancellationToken);
            Console.WriteLine("### Enviando Mensagem Somente Para Mim ###");
            await hubService.ManageMessage("Meu processo não pode ser finalizado com sucesso!", "SendMessageToCaller", cancellationToken);

            await Task.Delay(2000, cancellationToken);
            Console.WriteLine("### Entrando no Grupo01 ###");
            await hubService.AddToGroup("Teste01", cancellationToken);

            await Task.Delay(4000, cancellationToken);
            Console.WriteLine("### Enviando Mensagem Somente o Grupo 'Teste01' ###");
            await hubService.ManageMessage("Opa", "SendMessageToGroup", cancellationToken, "Teste01");

            await Task.Delay(6000, cancellationToken);
            await hubService.ManageMessage("Entendido", "SendMessageToGroup", cancellationToken, "Teste01");
            await hubService.ManageMessage("ClienteC, poderia sair do grupo por gentileza?", "SendMessageToGroup", cancellationToken, "Teste01");

            await Task.Delay(7000, cancellationToken);
            await hubService.ManageMessage("Certo, agora podemos continuar", "SendMessageToGroup", cancellationToken, "Teste01");
        }
    }
}
