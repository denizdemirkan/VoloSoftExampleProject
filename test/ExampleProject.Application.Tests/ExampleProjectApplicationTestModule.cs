using Volo.Abp.Modularity;

namespace ExampleProject;

[DependsOn(
    typeof(ExampleProjectApplicationModule),
    typeof(ExampleProjectDomainTestModule)
    )]
public class ExampleProjectApplicationTestModule : AbpModule
{

}
