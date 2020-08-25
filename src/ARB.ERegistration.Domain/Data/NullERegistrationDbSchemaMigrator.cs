using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ARB.ERegistration.Data
{
    /* This is used if database provider does't define
     * IERegistrationDbSchemaMigrator implementation.
     */
    public class NullERegistrationDbSchemaMigrator : IERegistrationDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}