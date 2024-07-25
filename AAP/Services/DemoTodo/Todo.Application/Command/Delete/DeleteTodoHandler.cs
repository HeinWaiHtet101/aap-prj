

using Todo.Domain.ValueObjects;

namespace Todo.Application.Command.Delete;

public class DeleteTodoHandler(ITodoService service)
    : ICommandHandler<DeleteTodoCommand, DeleteTodoResult>
{
    public async Task<DeleteTodoResult> Handle(
        DeleteTodoCommand command,
        CancellationToken cancellationToken)
    {
        // Delete command to infrastructure
        var result = await service.DeleteTodo(TodoId.Of(command.id));
        
        // respond to api
        return new DeleteTodoResult(result);
    }
}
