using Microsoft.Extensions.DependencyInjection;
using Server.SignalR.Domain.Configurations;

namespace Server.SignalR
{
    /// <summary>
    /// Realiza o registros necessários no container de injeção de dependência do Asp.Net Core
    /// </summary>
    public static class SignalRServiceRegistration
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterSignalR(this IServiceCollection services)
        {
            // Utilizando Redis como Backplane (Mensagens só funcionarão com a conexão Redis)
            //services.AddSignalR().AddStackExchangeRedis($"{Settings.Redis.Server}:{Settings.Redis.Port},password={Settings.Redis.Password}", options => {
            //    options.Configuration.ChannelPrefix = "SignalR.Hackbart";
            //});

            // Não utilizando Redis como Backplane (MEnsagens funcionarão corretamente)
            services.AddSignalR();

            return services;
        }
    }
}
