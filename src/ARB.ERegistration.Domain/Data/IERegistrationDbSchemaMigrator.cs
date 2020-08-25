using System.Threading.Tasks;

namespace ARB.ERegistration.Data
{
    public interface IERegistrationDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
