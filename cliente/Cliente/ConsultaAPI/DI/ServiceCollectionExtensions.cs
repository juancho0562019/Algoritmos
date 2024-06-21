using Cliente.ConsultaAPI.Client;
using Cliente.ConsultaAPI.Client.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace Cliente.ConsultaAPI.DI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiClient(
            this IServiceCollection services,
            Action<ClientOptions> options)
        {
            services.AddSingleton<IApiClient, ApiClient>(_ =>
            {
                var clientOptions = new ClientOptions();
                options?.Invoke(clientOptions);

                return ClientFactory.Create(clientOptions);
            });

            return services;
        }
    }
}
