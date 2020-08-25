using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace ARB.ERegistration.EntityFrameworkCore
{
    [DependsOn(
        typeof(ERegistrationEntityFrameworkCoreModule)
        )]
    public class ERegistrationEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ERegistrationMigrationsDbContext>();
        }
    }
}
