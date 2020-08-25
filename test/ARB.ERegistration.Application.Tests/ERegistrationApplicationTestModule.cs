using Volo.Abp.Modularity;

namespace ARB.ERegistration
{
    [DependsOn(
        typeof(ERegistrationApplicationModule),
        typeof(ERegistrationDomainTestModule)
        )]
    public class ERegistrationApplicationTestModule : AbpModule
    {

    }
}