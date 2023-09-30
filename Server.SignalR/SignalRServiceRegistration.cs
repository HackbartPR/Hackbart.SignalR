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
            services.AddSignalR().AddStackExchangeRedis($"{Settings.Redis.Server}:{Settings.Redis.Port},password={Settings.Redis.Password}", options => {
                options.Configuration.ChannelPrefix = "SignalR.Hackbart";
            });

            return services;
        }
    }
}
