# Hackbart.SignalR

Este projeto tem como objetivo servir como base para a criação de um **servidor SignalR**.

Possuímos um Hub, chamado de ChatHub, **fortemente tipado** conectado a um **backplane**, o qual está utilizando o servidor Redis. 
Este hub possuí três métodos principais de enviar mensagens que são: 
- Enviar mensagem para todos conectados no Hub;
- Enviar mensagem para de volta para quem enviou (mais comum em notificações de processos)
- Enviar mensagem para um grupo específico.

Possuímos **três clientes**, três mini projetos Console Application separados, os quais são os clientes conetados ao servidor.
Devido estes clientes serem um Console Application, foi inserido dentro de cada um deles um **Host Service (Background Service)**, ou seja,
ao iniciar a aplicação **cada cliente inicia um processo em segundo plano**.
Cada background service roda **duas tarefas em paralelo**, sendo o processo de escuta de mensagens do ChatHub e um processo que envia mensagens.
Foi necessário colocar este dois processos paralelos, para o cliente conseguir ficar ouvindo o tempo todo as mensagens trocadas e ainda poder enviar
mensagens quando quiser.

Quase sempre as conexões com os Hubs devem possuir alguma autenticação, mas nos casos de ser algum service interno (outro backend) se comunicando com
o HubService, de modo que consiga enviar mensagem para os clientes (frontend), neste caso a autenticação não se torna necessária, portanto deve existir
alguma maneira de enviar mensagens para dentro do Hub sem estar conectado diretamente a ele ou até mesmo no caso de você possuir um controller, um job que 
ao finalizar sua execução precisa avisar um usuário conectado ao hub que o processo foi finalizado, portanto temos a comunicação com o hub ocorrendo fora 
da sua conexão. **Utilizando o HubContext podemos enviar mensagens para o hub não estando conectado a ele**.

### Observação
Para utilizar o backplane deve-se comentar a linha 24 do arquivo SignalRServiceRegistration.cs e descomentar as linha 19, 20 e 21. Lembrando que para estes casos deve-se
possuir um servidor Redis.
