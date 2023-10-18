using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace ExampleProject.Web;

[Dependency(ReplaceServices = true)]
public class ExampleProjectBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ExampleProject";
}
