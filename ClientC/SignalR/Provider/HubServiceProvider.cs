using ClientC.Domain.Configurations;
using Microsoft.AspNetCore.SignalR.Client;

namespace ClientC.SignalR.Provider
{
    /// <summary>
    /// Proverá a conexão com o ChatHub do servidor
    /// </summary>
    public class HubServiceProvider
    {
        public HubConnection Connection { get; internal set; }

        /// <summary>
        /// Cria uma conexão com o ChatHub do servidor
        /// </summary>
        public HubServiceProvider()
            => Connection = new HubConnectionBuilder().WithUrl($"{Settings.HubProvider.Url}").Build();
    }
}
