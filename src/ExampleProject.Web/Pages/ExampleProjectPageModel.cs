using ExampleProject.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ExampleProject.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ExampleProjectPageModel : AbpPageModel
{
    protected ExampleProjectPageModel()
    {
        LocalizationResourceType = typeof(ExampleProjectResource);
    }
}
