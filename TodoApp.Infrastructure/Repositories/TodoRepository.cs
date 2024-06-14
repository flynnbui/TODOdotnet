using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TodoApp.Core.Entities;
using TodoApp.Core.Interfaces;
using TodoApp.Infrastructure.Data;

namespace TodoApp.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public TodoRepository(ApplicationDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _httpContext = httpContext ?? throw new ArgumentNullException(nameof(httpContext));
        }

        public async Task<Todo> GetByIdAsync(int id)
        {
            try
            {
                var todo = await _context.Todos.FindAsync(id);
                if (todo == null)
                {
                    throw new Exception($"Todo with Id '{id}' not found.");
                }
                else if (todo.OwnerId != _httpContext.HttpContext.User.Identity.Name)
                {
                    throw new Exception("You are not authorized to access this todo.");
                }
                return todo;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting a todo by Id.", ex);
            }
        }


        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            try
            {
                // Get all todos that belong to the current user
                var todos = await _context.Todos
                .Where(x => x.OwnerId.Contains(_httpContext.HttpContext.User.Identity.Name))
                .ToListAsync();
                return todos;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting all todos.", ex);
            }
        }

        public async Task AddAsync(Todo todo)
        {
            if (todo == null)
            {
                throw new ArgumentNullException(nameof(todo));
            }

            try
            {
                await _context.Todos.AddAsync(todo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding a todo.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var todo = await GetByIdAsync(id);
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting a todo.", ex);
            }
        }

        public async Task UpdateAsync(Todo todo)
        {
            if (todo == null)
            {
                throw new ArgumentNullException(nameof(todo));
            }

            try
            {
                _context.Todos.Update(todo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating a todo.", ex);
            }
        }
    }
}
