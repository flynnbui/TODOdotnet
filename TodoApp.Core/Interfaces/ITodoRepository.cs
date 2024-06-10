using TodoApp.Core.Dtos;
using TodoApp.Core.Entities;

namespace TodoApp.Core.Interfaces;

public interface ITodoRepository
{
    Task<Todo> GetByIdAsync(int id);
    Task<IEnumerable<Todo>> GetAllAsync();
    Task AddAsync (Todo todo);
    Task UpdateAsync (Todo todo);
    Task DeleteAsync (int id);
}