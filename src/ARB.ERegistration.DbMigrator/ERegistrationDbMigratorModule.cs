using ARB.ERegistration.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ARB.ERegistration.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ERegistrationEntityFrameworkCoreDbMigrationsModule),
        typeof(ERegistrationApplicationContractsModule)
        )]
    public class ERegistrationDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
