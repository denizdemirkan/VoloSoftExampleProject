using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ExampleProject.Data;
using Volo.Abp.DependencyInjection;

namespace ExampleProject.EntityFrameworkCore;

public class EntityFrameworkCoreExampleProjectDbSchemaMigrator
    : IExampleProjectDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreExampleProjectDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the ExampleProjectDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<SqlServerBookStoreDbContext>()
            .Database
            .MigrateAsync();
    }
}
