using ClientA.SignalR.Service.Abstraction;

namespace ClientA
{
    /// <summary>
    /// Essa classe foi criada somente para organizar as mensagens que serão trocadas
    /// </summary>
    public static class Chat
    {
        //public static async Task EnviarMensagem(IHubService hubService, CancellationToken cancellationToken)
        //{
        //    Console.WriteLine("### Enviando Mensagem Para Todos ###");
        //    await hubService.ManageMessage("Olá", "SendMessageToAll", cancellationToken);

        //    await Task.Delay(4000, cancellationToken);
        //    await hubService.ManageMessage("Tudo certo?", "SendMessageToAll", cancellationToken);

        //    await Task.Delay(3000, cancellationToken);
        //    Console.WriteLine("### Enviando Mensagem Somente Para Mim ###");
        //    await hubService.ManageMessage("Meu processo foi finalizado com sucesso!", "SendMessageToCaller", cancellationToken);

        //    await Task.Delay(1000, cancellationToken);
        //    Console.WriteLine("### Entrando no Grupo01 ###");
        //    await hubService.AddToGroup("Teste01", cancellationToken);

        //    await Task.Delay(4000, cancellationToken);
        //    Console.WriteLine("### Enviando Mensagem Somente o Grupo 'Teste01' ###");
        //    await hubService.ManageMessage("Olá Grupo", "SendMessageToGroup", cancellationToken, "Teste01");

        //    await Task.Delay(8000, cancellationToken);
        //    await hubService.ManageMessage("Esta conversa é exclusiva deste grupo", "SendMessageToGroup", cancellationToken, "Teste01");

        //    await Task.Delay(12000, cancellationToken);
        //    await hubService.ManageMessage("Beleza", "SendMessageToGroup", cancellationToken, "Teste01");
        //}

        public static async Task EnviarMensagem(IHubService hubService, CancellationToken cancellationToken)
        {
            Console.WriteLine("### Enviando Mensagem Para Todos ###");
            await hubService.ManageMessage("Olá", "SendMessageToAll", cancellationToken);

            await Task.Delay(4000, cancellationToken);
            await hubService.ManageMessage("Tudo certo?", "SendMessageToAll", cancellationToken);

            await Task.Delay(2000, cancellationToken);
            Console.WriteLine("### Enviando Mensagem Somente Para Mim ###");
            await hubService.ManageMessage("Meu processo foi finalizado com sucesso!", "SendMessageToCaller", cancellationToken);

            await Task.Delay(2000, cancellationToken);
            Console.WriteLine("### Entrando no Grupo01 ###");
            await hubService.AddToGroup("Teste01", cancellationToken);

            await Task.Delay(4000, cancellationToken);
            Console.WriteLine("### Enviando Mensagem Somente o Grupo 'Teste01' ###");
            await hubService.ManageMessage("Olá Grupo", "SendMessageToGroup", cancellationToken, "Teste01");

            await Task.Delay(4000, cancellationToken);
            await hubService.ManageMessage("Esta conversa é exclusiva deste grupo", "SendMessageToGroup", cancellationToken, "Teste01");

            await Task.Delay(10000, cancellationToken);
            await hubService.ManageMessage("Beleza", "SendMessageToGroup", cancellationToken, "Teste01");
        }
    }
}
