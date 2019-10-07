using IdentifierGenerator.Application;
using IdentifierGenerator.Domain;
using IdentifierGenerator.Infrastructure;
using IdentifierGenerator.Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IdentifierGenerator.Bootstrap
{
    public static class Bootstrapper
    {
        public static void ConfigureServices(IServiceCollection services, string dbContextConnectionString)
        {
            services.AddDbContext<IdentifierGeneratorDbContext>(x => x.UseSqlServer(dbContextConnectionString));
            services.AddScoped<IIdentifierRepository, IdentifierRepository>();
            services.AddScoped<IIdentifierService, IdentifierService>();
            services.AddScoped<FactoryCategoryGeneratedIdentifiersQuery>();
            services.AddScoped<AllIdentifierQuery>();
        }
    }
}
