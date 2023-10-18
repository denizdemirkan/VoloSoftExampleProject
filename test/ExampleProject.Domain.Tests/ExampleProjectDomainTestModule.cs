using ExampleProject.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ExampleProject;

[DependsOn(
    typeof(ExampleProjectEntityFrameworkCoreTestModule)
    )]
public class ExampleProjectDomainTestModule : AbpModule
{

}
