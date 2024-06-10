using TodoApp.Core.Dtos;
using TodoApp.Core.Entities;

namespace TodoApp.Core.Interfaces;

public interface ITodoService
{
    Task<IEnumerable<Todo>> GetAllTodosAsync();
    Task<Todo> GetTodoByIdAsync(int id);
    Task CreateTodoAsync(Todo todo);
    Task UpdateTodoAsync(Todo todo);
    Task DeleteTodoAsync(int id);
}