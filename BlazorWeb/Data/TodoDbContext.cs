using BlazorWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorWeb.Data;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; } = null!;
}
