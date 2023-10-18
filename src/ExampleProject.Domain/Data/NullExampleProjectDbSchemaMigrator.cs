using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ExampleProject.Data;

/* This is used if database provider does't define
 * IExampleProjectDbSchemaMigrator implementation.
 */
public class NullExampleProjectDbSchemaMigrator : IExampleProjectDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
