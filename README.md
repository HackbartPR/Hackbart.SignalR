# Hackbart.SignalR

Este projeto ainda está em progresso, mas será usado para criar um servidor SignalR fortemente tipado com troca de mensagens dentro e fora dos hubs e utilizando o Redis como backplane para casos de várias intâncias do servidor. O mesmo estará conteinerizado para poder ser usado como um Container App na Azure ou em outras plataformas.

Atualmente temos um Servidor com Hub Fortmente Tipado, recebendo mensagens somente de dentro do Hub. Temos três clientes conectados trocando mensagem em tempo real.
Estes clientes possuem um Background Service executando duas tarefas em paralelo, sendo elas ouvir todas as mensagens trocadas e mandar mensagens.

Caso você leitor queira testar. Somente baixar a aplicação, abrí-la no Visual Studio, verificar se todos os projetos estão para inicializar juntos e clicar em Iniciar.
