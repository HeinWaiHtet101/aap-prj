
namespace Todo.Application.Exceptions;

internal class TodoNotFoundException: NotFoundException
{
    public TodoNotFoundException(Guid id): base("Todo", id) { }
}
