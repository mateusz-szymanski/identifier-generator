using IdentifierGenerator.Application.IoC;
using IdentifierGenerator.Infrastructure.IoC;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Linq;

namespace IdentifierGenerator.Application.UnitTests.IoC
{
    public static class ServiceCollectionExtensions
    {
        private static IServiceCollection AddNullLogging(this IServiceCollection services)
        {
            services.TryAdd(ServiceDescriptor.Singleton<ILoggerFactory, NullLoggerFactory>());
            services.TryAdd(ServiceDescriptor.Singleton(typeof(ILogger<>), typeof(NullLogger<>)));

            return services;
        }

        public static IServiceCollection AddDefaultServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddNullLogging();
            services.AddApplicationServices();
            services.AddInfrastructureServices(configuration);

            return services;
        }

        public static IServiceCollection SwitchToSqliteDbContextOptions<TDbContext>(this IServiceCollection services,
            string sqliteConnectionString)
            where TDbContext : DbContext
        {
            var dbContextOptionsDescriptor = services
                .FirstOrDefault(d => d.ServiceType == typeof(DbContextOptions<TDbContext>));

            if (dbContextOptionsDescriptor is not null)
                services.Remove(dbContextOptionsDescriptor);

            var sqliteDbContextOptions = new DbContextOptionsBuilder<TDbContext>()
                .UseSqlite(sqliteConnectionString)
                .Options;

            var serviceDescriptor = new ServiceDescriptor(typeof(DbContextOptions<TDbContext>), sqliteDbContextOptions);
            services.Add(serviceDescriptor);

            return services;
        }
    }
}
