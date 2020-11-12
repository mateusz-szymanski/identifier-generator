using IdentifierGenerator.Application.UnitTests.Database;
using IdentifierGenerator.Application.UnitTests.IoC;
using IdentifierGenerator.Infrastructure.DbContextConfiguration;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace IdentifierGenerator.Application.UnitTests
{
    class ServiceProviderBuilder
    {
        private readonly IConfiguration _configuration;
        private readonly string _sqliteConnectionString;

        public ServiceProviderBuilder()
        {
            _configuration = new ConfigurationBuilder().Build();
            _sqliteConnectionString = PrepareSqliteConnectionString();
        }

        private static string PrepareSqliteConnectionString()
        {
            var databaseCatalog = "SqliteTestDatabases";
            var databaseName = $"IdentifierGenerator-{Guid.NewGuid()}";

            if (!Directory.Exists(databaseCatalog))
                Directory.CreateDirectory(databaseCatalog);

            var databaseFilePath = Path.Combine(databaseCatalog, databaseName);

            var sqliteConnectionStringBuilder = new SqliteConnectionStringBuilder();
            sqliteConnectionStringBuilder.DataSource = databaseFilePath;

            return sqliteConnectionStringBuilder.ConnectionString;
        }

        public async Task<ServiceProvider> Build()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton(_configuration);
            services.AddDefaultServices(_configuration);

            services.SwitchToSqliteDbContextOptions<IdentifierGeneratorDbContext>(_sqliteConnectionString);
            services.AddScoped<DatabaseMigrator>();

            var serviceProvider = services.BuildServiceProvider();

            await serviceProvider.GetRequiredService<DatabaseMigrator>().EnsureCreated();

            return serviceProvider;
        }
    }
}
