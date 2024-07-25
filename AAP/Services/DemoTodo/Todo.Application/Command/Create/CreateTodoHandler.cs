



using Mapster;
using Todo.Domain.ValueObjects;

namespace Todo.Application.Command.Create;

public class CreateTodoHandler(ITodoService todoService)
    : ICommandHandler<CreateTodoCommand, CreateTodoResult>
{
    public async Task<CreateTodoResult> Handle(
        CreateTodoCommand command,
        CancellationToken cancellationToken)
    {
        // Set Command to entity
        var todo = command.GetTodo();

        // Db process
        var result = await todoService.AddTodo(todo);

        // Response
        return result.Adapt<CreateTodoResult>();
    }
}
