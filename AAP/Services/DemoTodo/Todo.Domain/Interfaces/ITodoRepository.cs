
namespace Todo.Domain.Interfaces;

public interface ITodoRepository
{
    Task<Todo.Domain.Entities.Todo> GetToByIdAsync(TodoId id);
    Task<IEnumerable<Todo.Domain.Entities.Todo>> GetAllAsync();
    Task<Guid> AddAsync(Todo.Domain.Entities.Todo todo);
    Task<bool> UpdateAsync(Todo.Domain.Entities.Todo todo);
    Task<bool> DeleteAsync(TodoId id);
}
