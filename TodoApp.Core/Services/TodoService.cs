using TodoApp.Core.DTOs;
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
        return await _todoRepository.GetAllAsync();
    }

    public async Task<Todo> GetTodoByIdAsync(int id)
    {
        return await _todoRepository.GetByIdAsync(id);
    }

    public async Task<Todo> CreateTodoAsync(Todo todo)
    {
        await _todoRepository.AddAsync(todo);
        return todo;
    }

    public async Task<Todo> UpdateTodoAsync(Todo todo)
    {
        await _todoRepository.UpdateAsync(todo);
        return todo;
    }

    public async Task DeleteTodoAsync(int id)
    {
        await _todoRepository.DeleteAsync(id);
    }

}