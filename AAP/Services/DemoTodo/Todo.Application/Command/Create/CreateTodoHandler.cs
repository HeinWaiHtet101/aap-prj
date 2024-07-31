
namespace Todo.Application.Command.Create;

public class CreateTodoHandler(ITodoService todoService)
    : ICommandHandler<CreateTodoCommand, CreateTodoResult>
{
    public async Task<CreateTodoResult> Handle(
        CreateTodoCommand command,
        CancellationToken cancellationToken)
    {
        // Set Command to entity
        var todo = command.GetTodoByCreateTodoDto();

        // Db process
        var result = await todoService.AddTodo(todo);

        // Response
        return new CreateTodoResult(result);
    }
}
