

namespace Todo.Infrastructure.Repositories;

public class TodoRepository(ApplicationDbContext context)
    : ITodoRepository
{
    public async Task<Guid> AddAsync(Domain.Entities.Todo todo)
    {
        await context.Todo.AddAsync(todo);
        await context.SaveChangesAsync();
        return todo.Id.Value;
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
        context.Todo.Update(todo);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(TodoId id)
    {
        var data = await GetTodoById(id);

        if (data is null)
            throw new TodoNotFoundException(id.Value);

        context.Todo.Remove(data);
        await context.SaveChangesAsync();
        return true;
    }

    private async Task<Domain.Entities.Todo?> GetTodoById(TodoId id)
    {
        return await context.Todo
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
