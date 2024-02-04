using System.Threading.Tasks;

namespace VumbaSoft.AdventureWorksAbp.Data;

public interface IAdventureWorksAbpDbSchemaMigrator
{
    Task MigrateAsync();
}
