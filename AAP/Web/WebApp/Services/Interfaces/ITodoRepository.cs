using WebApp.Models;

namespace WebApp.Services.Interfaces;

public interface ITodoRepository
{
    Task<Guid> AddAsync(string name, bool isDone, DateTime createdDate, DateTime updatedDate);
    Task<IEnumerable<TodoWrapper?>> GetAllAsync();
    Task<TodoWrapper?> GetByIdAsync(Guid id);
    Task<bool> UpdateAsync(Todo item);
    Task<bool> DeleteAsync(Guid id);
}
