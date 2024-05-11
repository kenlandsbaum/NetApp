using Bunit;

namespace BlazorWeb.Components.Pages;

public class CounterTest: TestContext
{
    [Fact]
    public void Can_Update_Dom_With_Button()
    {
        var cut =  RenderComponent<Counter>();
        var button = cut.Find("button");
        
        var p = cut.Find("p");
        Assert.Equal("Current count: 0", p.TextContent);

        for (var i = 0; i < 5; i++) {
            button.Click();
        }

        Assert.Equal("Current count: 5", p.TextContent);
    }
}