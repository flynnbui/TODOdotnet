using TodoApp.Core.Dtos;
using TodoApp.Core.Entities;
using TodoApp.Core.Interfaces;

namespace TodoApp.Core.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;
    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<IEnumerable<Todo>> GetAllTodosAsync()
    {
        await _todoRepository.GetAllAsync();
    }

    public async Task<Todo> GetTodoByIdAsync(int id)
    {
        await _todoRepository.GetByIdAsync(id);
    }

    public async Task CreateTodoAsync(Todo todo)
    {
        await _todoRepository.AddAsync(todo);
    }

    public async Task UpdateTodoAsync(Todo todo)
    {
        await _todoRepository.UpdateAsync(todo);
    }

    public async Task DeleteTodoAsync(int id)
    {
        await _todoRepository.DeleteAsync(id);
    }

}