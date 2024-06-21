using Application.Commons.Behaviours;
using Domain.Interfaces;
using Domain.UseCases;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddSingleton<IPatronExtraccionStrategyFactory, PatronExtraccionStrategyFactory>();
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

            });


            return services;
        }
    }
}
