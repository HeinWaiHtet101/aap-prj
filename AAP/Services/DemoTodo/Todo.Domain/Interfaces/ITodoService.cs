namespace Todo.Domain.Interfaces;

public interface ITodoService
{
    Task<Todo.Domain.Entities.Todo> GetTodoById(TodoId id);
    Task<IEnumerable<Todo.Domain.Entities.Todo>> GetAllTodos();
    Task<bool> AddTodo(Todo.Domain.Entities.Todo todo);
    Task<bool> UpdateTodo(Todo.Domain.Entities.Todo todo);
    Task<bool> DeleteTodo(TodoId id);
}
