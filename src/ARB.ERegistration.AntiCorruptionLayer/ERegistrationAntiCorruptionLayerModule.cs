using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace ARB.ERegistration.AntiCorruptionLayer
{
    [DependsOn(
       typeof(ERegistrationDomainModule)
       )]
    public class ERegistrationAntiCorruptionLayerModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<ERegistrationAntiCorruptionLayerModule>();
            });
        }
    }
}
