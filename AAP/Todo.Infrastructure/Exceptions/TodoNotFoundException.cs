

namespace Todo.Infrastructure.Exceptions;

public class TodoNotFoundException : NotFoundException
{
    public TodoNotFoundException(Guid id) : base("Todo", id) { }
}

