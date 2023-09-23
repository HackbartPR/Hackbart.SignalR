using Microsoft.Extensions.Configuration;

namespace ClientA.Domain.Configurations
{
    /// <summary>
    /// Conexões com Hub
    /// </summary>
    public struct HubProvider
    {
        public string Url { get; set; }
    }

    /// <summary>
    /// Configurações da aplicação
    /// </summary>
    public struct Application
    {
        public string ClientName { get; set; }
    }

    /// <summary>
    /// Responsável por preencher e fornecer a HubProvider
    /// </summary>
    public static class Settings
    {
        public static HubProvider HubProvider { get; private set;}
        public static Application Application { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public static void Configure(IConfiguration configuration)
        {
            HubProvider = new HubProvider
            {
                Url = configuration.GetSection("HubService:Url").Value
            };
            Application = new Application
            {
                ClientName = configuration.GetSection("Application:ClientName").Value
            };
        }
    }
}
