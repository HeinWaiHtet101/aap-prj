
namespace Todo.Application.Command.Create;

public record CreateTodoCommand(
    string name,
    bool isDone,
    DateTime startDate,
    DateTime endDate): ICommand<CreateTodoResult>;
