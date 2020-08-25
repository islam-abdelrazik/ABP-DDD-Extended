using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace ARB.ERegistration.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(ERegistrationHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class ERegistrationConsoleApiClientModule : AbpModule
    {
        
    }
}
