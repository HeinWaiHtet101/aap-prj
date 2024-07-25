

namespace Todo.Application.Query.GetById;

public record GetTodoByIdQuery(
    Guid id): IQuery<GetTodoByIdResult>;
