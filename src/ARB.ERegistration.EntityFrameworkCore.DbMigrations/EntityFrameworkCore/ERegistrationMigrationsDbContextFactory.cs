using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ARB.ERegistration.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class ERegistrationMigrationsDbContextFactory : IDesignTimeDbContextFactory<ERegistrationMigrationsDbContext>
    {
        public ERegistrationMigrationsDbContext CreateDbContext(string[] args)
        {
            ERegistrationEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<ERegistrationMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new ERegistrationMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
