using ExampleProject.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ExampleProject.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ExampleProjectController : AbpControllerBase
{
    protected ExampleProjectController()
    {
        LocalizationResource = typeof(ExampleProjectResource);
    }
}
