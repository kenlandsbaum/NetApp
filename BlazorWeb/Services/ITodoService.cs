using BlazorWeb.Models;

namespace BlazorWeb.Services;

public interface ITodoService
{
    public Task<IEnumerable<TodoItem>> GetTodosAsync();
    public Task PostTodoAsync(TodoItem todoItem);
    public Task PutTodoAsync(long id, TodoItem todoItem);
    public Task DeleteTodoAsync(long id);
}