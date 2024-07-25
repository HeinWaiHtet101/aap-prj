
namespace Todo.Application.Command.Delete;

public record DeleteTodoCommand(Guid id)
    : ICommand<DeleteTodoResult>;

