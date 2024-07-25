
using Mapster;

namespace Todo.Application.Query.Get;

public class GetTodoHandler(ITodoService service)
    : IQueryHandler<GetTodoQuery, GetTodoResult>
{
    public async Task<GetTodoResult> Handle(GetTodoQuery request, CancellationToken cancellationToken)
    {
        // Db Process
        var result = await service.GetAllTodos();

        // Respond
        return result.Adapt<GetTodoResult>();
    }
}
