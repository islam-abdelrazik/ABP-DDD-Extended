using ARB.ERegistration.Audit;
using ARB.ERegistration.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Volo.Abp.Account;
using Volo.Abp.Auditing;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.TenantManagement;
using Volo.Abp.VirtualFileSystem;

namespace ARB.ERegistration
{
    [DependsOn(
        typeof(ERegistrationApplicationContractsModule),
        typeof(AbpAccountHttpApiModule),
        typeof(AbpIdentityHttpApiModule),
        typeof(AbpPermissionManagementHttpApiModule),
        typeof(AbpTenantManagementHttpApiModule),
        typeof(AbpFeatureManagementHttpApiModule),
        typeof(AbpLocalizationModule)
        )]
    public class ERegistrationHttpApiModule : AbpModule
    {
        //Enable auditing
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            #region Audit Trail
            Configure<AbpAuditingOptions>(options =>
            {
                options.IsEnabled = true; //False disables the auditing system
                options.IsEnabledForGetRequests = true;
                options.IsEnabledForAnonymousUsers = true;
                options.AlwaysLogOnException = true;
                options.Contributors.Add(new CustomAuditLogContributor());
            });
            #endregion

            #region Localization
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<ERegistrationHttpApiModule>();
            });
            #endregion

            #region Error Codes
            context.Services.Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("ERegistrationDomainErrorCodes", typeof(ERegistrationResource));
            });
            #endregion


        }
    }
}
