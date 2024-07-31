using WebApp.Models;

namespace WebApp.Services.Interfaces;

public interface ITodoRepository
{
    Task<Guid> AddAsync(string name, bool isDone, DateTime createdDate, DateTime updatedDate);
    Task<TodoList> GetAllAsync();
    Task<TodoWrapper?> GetByIdAsync(Guid id);
    Task<UpdateTodo> UpdateAsync(Todo item);
    Task<DeleteTodo> DeleteAsync(Guid id);
}
