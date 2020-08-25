using ARB.ERegistration.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ARB.ERegistration
{
    [DependsOn(
        typeof(ERegistrationEntityFrameworkCoreTestModule)
        )]
    public class ERegistrationDomainTestModule : AbpModule
    {

    }
}