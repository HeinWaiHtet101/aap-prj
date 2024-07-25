
namespace Todo.Application.Command.Update;

public class UpdateTodoHandler(ITodoService service)
    : ICommandHandler<UpdateTodoCommand, UpdateTodoResult>
{
    public async Task<UpdateTodoResult> Handle(
        UpdateTodoCommand command,
        CancellationToken cancellationToken)
    {
        // map command as Entity
        var todo = command.GetTodoByUpdateTodoDto();

        // update via infra layer
        var result = await service.UpdateTodo(todo);

        return new UpdateTodoResult(result);
    }
}
