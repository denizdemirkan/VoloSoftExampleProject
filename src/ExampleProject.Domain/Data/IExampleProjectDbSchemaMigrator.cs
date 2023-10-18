using System.Threading.Tasks;

namespace ExampleProject.Data;

public interface IExampleProjectDbSchemaMigrator
{
    Task MigrateAsync();
}
