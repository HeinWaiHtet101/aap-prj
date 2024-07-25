

using Todo.Domain.Interfaces;

namespace Todo.Domain.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository repository;
    public TodoService(ITodoRepository repository)
    {
        this.repository = repository;
    }

    public async Task<Guid> AddTodo(Entities.Todo todo)
    {
        return await this.repository.AddAsync(todo);
    }

    public async Task<bool> DeleteTodo(TodoId id)
    {
        return await this.repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Entities.Todo>> GetAllTodos()
    {
        return await this.repository.GetAllAsync();
    }

    public async Task<Entities.Todo> GetTodoById(TodoId id)
    {
        return await this.repository.GetToByIdAsync(id);
    }

    public async Task<bool> UpdateTodo(Entities.Todo todo)
    {
        return await this.repository.UpdateAsync(todo);
    }
}
