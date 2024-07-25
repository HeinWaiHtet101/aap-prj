namespace Todo.Application.Command.Update;

public record UpdateTodoCommand(
    Guid id,
    string name,
    bool isDone,
    DateTime startDate,
    DateTime endDate): ICommand<UpdateTodoResult>;
