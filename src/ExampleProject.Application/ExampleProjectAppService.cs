using System;
using System.Collections.Generic;
using System.Text;
using ExampleProject.Localization;
using Volo.Abp.Application.Services;

namespace ExampleProject;

/* Inherit your application services from this class.
 */
public abstract class ExampleProjectAppService : ApplicationService
{
    protected ExampleProjectAppService()
    {
        LocalizationResource = typeof(ExampleProjectResource);
    }
}
