
using Todo.Application.Command.Create;
using Todo.Application.Command.Update;
using Todo.Domain.ValueObjects;

namespace Todo.Application.Mappings;

public static class TodoExtension
{
    public static Domain.Entities.Todo GetTodoByCreateTodoDto(this CreateTodoCommand entity)
    {
        var todo = Domain.Entities.Todo.Create(
            TodoId.Of(Guid.NewGuid()),
            TodoName.Of(entity.name),
            entity.isDone,
            entity.startDate,
            entity.endDate);
        return todo;
    }

    public static Domain.Entities.Todo GetTodoByUpdateTodoDto(this UpdateTodoCommand entity)
    {
        var todo = Domain.Entities.Todo.Create(
            TodoId.Of(entity.id),
            TodoName.Of(entity.name),
            entity.isDone,
            entity.startDate,
            entity.endDate);
        return todo;
    }

    public static TodoDto EntityToTodoDto(this Domain.Entities.Todo entity)
    {
        return new TodoDto(
            entity.Id.Value,
            entity.Name.Value,
            entity.IsDone,
            entity.StartDate,
            entity.EndDate);
    }

    public static IEnumerable<TodoDto> EntityToTodoDtoList(this IEnumerable<Domain.Entities.Todo> entities)
    {
        return entities.Select(
            entity => new TodoDto(
                entity.Id.Value,
                entity.Name.Value,
                entity.IsDone,
                entity.StartDate,
                entity.EndDate));
    }
}
