using Microsoft.Extensions.DependencyInjection;

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
            services.AddSignalR();
            return services;
        }
    }
}
