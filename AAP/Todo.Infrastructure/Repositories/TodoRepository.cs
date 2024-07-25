

using Mapster;
using Todo.Domain.Interfaces;
using Todo.Domain.ValueObjects;

namespace Todo.Infrastructure.Repositories;

public class TodoRepository(ApplicationDbContext context)
    : ITodoRepository
{
    public async Task<bool> AddAsync(Domain.Entities.Todo todo)
    {
        await context.Todo.AddAsync(todo);
        return true;
    }

    public async Task<IEnumerable<Domain.Entities.Todo>> GetAllAsync()
    {
        var data = await context.Todo.ToListAsync();
        return data;
    }

    public async Task<Domain.Entities.Todo> GetToByIdAsync(TodoId id)
    {
        var data = await GetTodoById(id);

        if (data is null)
            throw new TodoNotFoundException(id.Value);

        return data;
    }

    public async Task<bool> UpdateAsync(Domain.Entities.Todo todo)
    {
        var data = await GetTodoById(todo.Id);

        if (data is null)
            throw new TodoNotFoundException(todo.Id.Value);

        data.Adapt<Domain.Entities.Todo>();
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(TodoId id)
    {
        var data = await GetTodoById(id);

        if (data is null)
            throw new TodoNotFoundException(id.Value);

        context.Todo.Remove(data);
        context.SaveChanges();
        return true;
    }

    private async Task<Domain.Entities.Todo?> GetTodoById(TodoId id)
    {
        return await context.Todo
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Value == id.Value);
    }
}
