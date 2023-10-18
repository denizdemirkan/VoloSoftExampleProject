using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace ExampleProject.Pages;

public class Index_Tests : ExampleProjectWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
