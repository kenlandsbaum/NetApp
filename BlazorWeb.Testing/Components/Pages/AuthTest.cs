using Bunit;
using Bunit.TestDoubles;

namespace BlazorWeb.Components.Pages;

public class AuthTest : TestContext
{
    [Fact]
    public void Auth_Renders_And_Displays_User()
    {
        var authContext = this.AddTestAuthorization();
        authContext.SetAuthorized("ken");

        var cut = RenderComponent<Auth>();

        Assert.Contains("Hello ken!", cut.Markup);
    }
}