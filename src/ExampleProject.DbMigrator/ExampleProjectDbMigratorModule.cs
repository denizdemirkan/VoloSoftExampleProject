using ExampleProject.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ExampleProject.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ExampleProjectEntityFrameworkCoreModule),
    typeof(ExampleProjectApplicationContractsModule)
    )]
public class ExampleProjectDbMigratorModule : AbpModule
{
}
