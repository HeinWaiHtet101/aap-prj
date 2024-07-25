


using Todo.Application.Exceptions;
using Todo.Domain.ValueObjects;

namespace Todo.Application.Query.GetById;

public class GetTodoByIdHandler(ITodoService service)
    : IQueryHandler<GetTodoByIdQuery, GetTodoByIdResult>
{
    public async Task<GetTodoByIdResult> Handle(
        GetTodoByIdQuery query,
        CancellationToken cancellationToken)
    {
        // Db
        var todo = await service.GetTodoById(TodoId.Of(query.id));

        if(todo is null)
        {
            throw new TodoNotFoundException(query.id);
        }

        //Map with Dto
        var response = todo.EntityToTodoDto();

        // response
        return new GetTodoByIdResult(response);
    }
}
