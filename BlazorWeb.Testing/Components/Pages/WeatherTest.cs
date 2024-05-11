using Bunit;
using System;

namespace BlazorWeb.Components.Pages;

public class WeatherTest : TestContext
{
    [Fact]
    public void Displays_Loading_Text()
    {
        var cut = RenderComponent<Weather>();
        var noTable = cut.FindAll("table");
        Assert.Empty(noTable);
        var p = cut.Find("p");
        Assert.Contains("This component demonstrates streaming data", p.TextContent);
        
        cut.WaitForElement("table");
        var table = cut.Find("table");
        Assert.NotNull(table);
        var trs = cut.FindAll("tr");
        Assert.Equal(6, trs.Count);
    }
}