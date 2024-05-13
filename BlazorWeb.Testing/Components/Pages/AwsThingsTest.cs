using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Amazon.S3.Model;
using BlazorWeb.Services;
using BlazorWeb.Testing.Services;

namespace BlazorWeb.Components.Pages;

public class AwsThingsTest: TestContext
{
    [Fact]
    public void Renders_Tab_UI()
    {
        Services.AddSingleton<IAwsS3Service>(new MockAwsS3Service());
        var cut = RenderComponent<AwsThings>();

        var tabs = cut.FindAll(".tab");
        Assert.Equal(3, tabs.Count);
        var h3 = cut.Find("h3");
        Assert.Contains("S3", h3.TextContent);

        tabs[1].Click();

        h3 = cut.Find("h3");
        Assert.Contains("Lambda", h3.TextContent);
        tabs = cut.FindAll(".tab");

        tabs[2].Click();
        h3 = cut.Find("h3");
        Assert.Contains("Cloudformation", h3.TextContent);
    }

    [Fact]
    public void Can_List_Buckets()
    {
        Services.AddSingleton<IAwsS3Service>(new MockAwsS3Service());
        var cut = RenderComponent<AwsThings>();

        var fetchButton = cut.Find(".btn.btn-info");
        fetchButton.Click();

        cut.WaitForElement("ul");

        var li = cut.FindAll("li");
        Assert.Equal(2, li.Count);
    }
}