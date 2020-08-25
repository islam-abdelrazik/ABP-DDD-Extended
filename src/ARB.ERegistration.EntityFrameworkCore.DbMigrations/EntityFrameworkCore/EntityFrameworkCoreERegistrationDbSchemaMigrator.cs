using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ARB.ERegistration.Data;
using Volo.Abp.DependencyInjection;

namespace ARB.ERegistration.EntityFrameworkCore
{
    public class EntityFrameworkCoreERegistrationDbSchemaMigrator
        : IERegistrationDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreERegistrationDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the ERegistrationMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<ERegistrationMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}