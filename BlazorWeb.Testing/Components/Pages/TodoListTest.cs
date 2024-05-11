using Bunit;
using Microsoft.Extensions.DependencyInjection;

using BlazorWeb.Services;
using BlazorWeb.Testing.Services;

namespace BlazorWeb.Components.Pages;

public class TodoListTest : TestContext
{
    [Fact]
    public void TodoList_Adds_Edits_Todos()
    {
        Services.AddSingleton<ITodoService>(new MockTodoService());

        var cut = RenderComponent<TodoList>();
        var h2 = cut.Find("h2");
        var p = cut.Find("p");
        Assert.NotNull(h2);
        Assert.NotNull(p);
        Assert.Equal("Todos", h2.TextContent);
        Assert.Equal("No todos right now.", p.TextContent);
        
        var input = cut.Find("input");
        input.Change("learn blazor");
        var button = cut.Find("button");
        button.Click();
        
        var li1 = cut.FindAll("li");
        Assert.NotEmpty(li1);
        li1.MarkupMatches(@"<li style=""list-style-type: none;border-top: 1px solid #ccc;"">
        <p style=""margin-top: 0.6em;"">
            <b>
            <i>learn blazor</i>
            </b>
        </p>
        <p>Completed: False</p>
        <button class=""btn btn-primary"">Toggle Complete</button>
        <button class=""btn btn-secondary"">Delete</button>
        </li>");

        var primaryButtons = cut.FindAll(".btn.btn-primary");
        Assert.NotNull(primaryButtons);
        primaryButtons[1].Click();

        li1 = cut.FindAll("li");
        li1.MarkupMatches(@"<li style=""list-style-type: none;border-top: 1px solid #ccc;"">
        <p style=""margin-top: 0.6em;"">
            <b>
            <i>learn blazor</i>
            </b>
        </p>
        <p>Completed: True</p>
        <button class=""btn btn-primary"">Toggle Complete</button>
        <button class=""btn btn-secondary"">Delete</button>
        </li>");
        
        var secondaryButton = cut.Find(".btn.btn-secondary");
        secondaryButton.Click();

        li1 = cut.FindAll("li");
        Assert.Empty(li1);

        var visibilityButton = cut.Find(".btn.btn-info");

        Assert.Contains("Show completed", visibilityButton.TextContent);
        visibilityButton.Click();
        visibilityButton.Click();
        li1 = cut.FindAll("li");
        Assert.Empty(li1);
    }
}