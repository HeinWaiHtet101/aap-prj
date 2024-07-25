
using Todo.Application.Command.Create;
using Todo.Domain.ValueObjects;

namespace Todo.Application.Mappings;

public static class TodoExtension
{
    public static Domain.Entities.Todo GetTodo(this CreateTodoCommand entity)
    {
        var todo = Domain.Entities.Todo.Create(
            TodoId.Of(Guid.NewGuid()),
            TodoName.Of(entity.name),
            entity.isDone,
            entity.startDate,
            entity.endDate);
        return todo;
    }
}
