using BlazorWeb.Services;
using BlazorWeb.Models;

namespace BlazorWeb.Testing.Services;

public class MockTodoService : ITodoService
{
    private List<TodoItem> _todos = new List<TodoItem>{};
    public async Task<IEnumerable<TodoItem>> GetTodosAsync()
    {
        Console.WriteLine("invoking MockTodoService.GetTodosAsync");
        return await Task.FromResult(_todos);
    }
    public Task PostTodoAsync(TodoItem todoItem)
    {
        Console.WriteLine("invoking MockTodoService.PostTodoAsync with {0}", todoItem);
        _todos.Add(todoItem);
        return Task.CompletedTask;
    }
    public Task PutTodoAsync(long id, TodoItem todoItem)
    {
        Console.WriteLine("invoking MockTodoService.PutTodoAsync with {0}", id);
        var todoToUpdate = _todos.Find(t => t.Id == id);
       if (todoToUpdate is null) 
       {
        return Task.CompletedTask;
       }
       todoToUpdate.Title = todoItem.Title;
       todoToUpdate.IsComplete = todoItem.IsComplete;
       return Task.CompletedTask;
    }

    public Task DeleteTodoAsync(long id)
    {
        Console.WriteLine("invoking MockTodoService.DeleteTodoAsync");
        _todos.RemoveAt((int)id - 1);
        return Task.CompletedTask;
    }

}
