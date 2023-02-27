using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vitasmart.Application.Interfaces;

namespace Vitasmart.Persistence.Npgsql
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IApplicationDbContext>(provider =>
                provider.GetService<ApplicationDbContext>()!);
            return services;
        }
    }
}