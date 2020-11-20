using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentifierGenerator.WebApi.CustomHealthChecks
{
    public class PendingMigrationsHealthCheck<TDbContext> : IHealthCheck
        where TDbContext : DbContext
    {
        private readonly IServiceProvider _serviceProvider;

        public PendingMigrationsHealthCheck(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken)
        {
            using var serviceScope = _serviceProvider.CreateScope();

            var dbContext = serviceScope.ServiceProvider.GetRequiredService<TDbContext>();
            var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync(cancellationToken);

            if (pendingMigrations.Any())
                return HealthCheckResult.Unhealthy("There are some migrations pending");

            return HealthCheckResult.Healthy("No pending migrations");
        }
    }
}
