using Announcer.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Announcer.Helpers.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services, string connectionString, string environmentName)
        {
            services.AddDbContext<AnnouncerDbContext>(options =>
            {
                //// If application is running in development mode, then use in memory database
                //if (string.IsNullOrWhiteSpace(environmentName) || environmentName == Environments.Development)
                //{
                    options.UseInMemoryDatabase("AnnouncerDb");
                //}
                //else
                //{
                //    options.UseSqlServer(connectionString);
                //}
            });

            return services;
        }
    }
}