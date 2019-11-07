using IdentifierGenerator.Bootstrap;
using IdentifierGenerator.Infrastructure;
using IdentifierGenerator.WebApi.HealthChecks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentifierGenerator.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            Bootstrapper.ConfigureServices(services, Configuration.GetConnectionString("IdentifierGeneratorContext"));

            services.AddControllers();

            services.AddHealthChecks()
                .AddDbContextCheck<IdentifierGeneratorDbContext>("dbContext")
                .AddCheck<PendingMigrationsHealthCheck<IdentifierGeneratorDbContext>>("pendingMigrations");

            services.AddCors(action =>
            {
                action.AddDefaultPolicy(policy => policy.AllowAnyOrigin()
                                                        .AllowAnyMethod()
                                                        .AllowAnyHeader()
                );
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHealthChecks("/"); // for gke - not possible to specify proper health check for ingress
            app.UseHealthChecks("/health");

            if (env.IsDevelopment())
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetService<IdentifierGeneratorDbContext>();
                    context.Database.Migrate();
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
