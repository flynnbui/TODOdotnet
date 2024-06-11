using TodoApp.Core.DTOs;
using TodoApp.Core.Entities;

namespace TodoApp.Core.Interfaces;

public interface ITodoService
{
    Task<IEnumerable<Todo>> GetAllTodosAsync();
    Task<Todo> GetTodoByIdAsync(int id);
    Task<Todo> CreateTodoAsync(Todo todo);
    Task<Todo> UpdateTodoAsync(Todo todo);
    Task DeleteTodoAsync(int id);
}