using Bunit;

namespace BlazorWeb.Components.Pages;

public class HomeTest : TestContext
{

    [Fact]    
    public void Can_Render_Home()
    {
        var renderedComponent = RenderComponent<Home>();
        VerifyDom(renderedComponent);
    }
    private void VerifyDom(IRenderedComponent<Home> renderedComponent)
    {
        var h1El = renderedComponent.FindAll("h1");
        Assert.Single(h1El);
        var homeText = h1El[0].TextContent;
        Assert.Equal("Hello, world!", homeText);
    }
}