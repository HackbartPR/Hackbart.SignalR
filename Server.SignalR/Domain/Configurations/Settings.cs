using Microsoft.Extensions.Configuration;

namespace Server.SignalR.Domain.Configurations
{
    /// <summary>
    /// Configurações do Servidor Redis
    /// </summary>
    public struct Redis
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string Server { get; set; }
        public string Port { get; set; }
    }

    /// <summary>
    /// Classe para manter as configurações
    /// </summary>
    public static class Settings
    {
        public static Redis Redis { get; internal set; }

        public static void Configure(IConfiguration configuration)
        {
            Redis = new Redis
            {
                User = configuration.GetSection("Redis:User").Value,
                Password = configuration.GetSection("Redis:Password").Value,
                Server = configuration.GetSection("Redis:Server").Value,
                Port = configuration.GetSection("Redis:Port").Value,
            };
        }
    }
}
