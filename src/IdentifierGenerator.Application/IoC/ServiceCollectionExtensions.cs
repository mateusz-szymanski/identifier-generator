using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace IdentifierGenerator.Application.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);

            return services;
        }
    }
}
