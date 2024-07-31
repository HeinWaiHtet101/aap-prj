namespace WebApp.Models;

public record TodoWrapper(
    Todo Todo);

public record TodoList
{
    public List<Todo> Todos { get; set; }
}

public record DeleteTodo(
    bool isSuccess);

public record UpdateTodo(
    bool isSuccess);

public record CreateTodo(
    Guid id);
