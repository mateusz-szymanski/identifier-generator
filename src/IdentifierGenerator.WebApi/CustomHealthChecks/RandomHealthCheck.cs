using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentifierGenerator.WebApi.CustomHealthChecks
{
    public class RandomHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken)
        {
            var random = new Random().Next(100);

            HealthCheckResult result;
            if (random % 3 == 0)
                result = HealthCheckResult.Unhealthy($"Random number was {random} - unfortunately it can be divided by 3");
            else
                result = HealthCheckResult.Healthy($"Random number was {random} - looks good");

            return Task.FromResult(result);
        }
    }
}
