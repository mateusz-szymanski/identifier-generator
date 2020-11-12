using IdentifierGenerator.Domain;
using IdentifierGenerator.Infrastructure.DbContextConfiguration;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentifierGenerator.Infrastructure.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var dbContextConnectionString = configuration.GetConnectionString("IdentifierGeneratorContext");
            services.AddDbContext<IdentifierGeneratorDbContext>(x => x.UseSqlServer(dbContextConnectionString));

            services.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);
            services.AddScoped<IIdentifierRepository, IdentifierRepository>();

            return services;
        }
    }
}
