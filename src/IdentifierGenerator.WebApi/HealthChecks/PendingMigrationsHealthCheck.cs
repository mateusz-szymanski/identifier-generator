using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentifierGenerator.WebApi.HealthChecks
{
    public class PendingMigrationsHealthCheck<TDbContext> : IHealthCheck
        where TDbContext : DbContext
    {
        private readonly IServiceProvider _serviceProvider;

        public PendingMigrationsHealthCheck(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var serviceScope = _serviceProvider.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<TDbContext>();
                if (dbContext.Database.GetPendingMigrations().Any())
                {
                    return Task.FromResult(HealthCheckResult.Unhealthy("There are some migrations pending"));
                }
            }

            return Task.FromResult(HealthCheckResult.Healthy("A healthy result"));
        }
    }
}
