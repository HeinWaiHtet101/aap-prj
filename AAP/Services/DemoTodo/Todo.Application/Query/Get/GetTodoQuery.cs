

namespace Todo.Application.Query.Get;

public record GetTodoQuery(
    int startPage = 1,
    int pageSize = 10): IQuery<GetTodoResult>;
