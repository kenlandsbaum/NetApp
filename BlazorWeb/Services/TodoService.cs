using Microsoft.EntityFrameworkCore;
using BlazorWeb.Models;
using BlazorWeb.Data;

namespace BlazorWeb.Services;

public class TodoService(TodoContext db, ILogger<TodoService> _logger) : ITodoService 
{
    
    public async Task<IEnumerable<TodoItem>> GetTodosAsync() 
    {
        _logger.LogInformation("getting todos {DT}", 
            DateTime.UtcNow.ToLongTimeString());
        return await db.TodoItems.ToArrayAsync();
    }

    public async Task PostTodoAsync(TodoItem todoItem) 
    {
        _logger.LogInformation("posting a todo {DT}", 
            DateTime.UtcNow.ToLongTimeString());
        db.TodoItems.Add(todoItem);
        await db.SaveChangesAsync();
    }

    public async Task PutTodoAsync(long id, TodoItem todoItem) 
    {
        _logger.LogInformation("updating a todo {DT}, {id}", 
            DateTime.UtcNow.ToLongTimeString(), id);
       var todoToUpdate = await db.TodoItems.FindAsync(id);
       if (todoToUpdate is null) 
       {
        return;
       }
       todoToUpdate.Title = todoItem.Title;
       todoToUpdate.IsComplete = todoItem.IsComplete;
       await db.SaveChangesAsync();
    }

    public async Task DeleteTodoAsync(long id) 
    {
        _logger.LogInformation("deleting a todo {DT}, {id}", 
            DateTime.UtcNow.ToLongTimeString(), id);
        var todoToDelete = await db.TodoItems.FindAsync(id);
        if (todoToDelete is null) 
        {
            return;
        }
        db.Remove(todoToDelete);
        await db.SaveChangesAsync();
    }

}