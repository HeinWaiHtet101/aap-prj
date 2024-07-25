
namespace Todo.Domain.Entities;

public class Todo
{
    public TodoId Id { get; private set; }

    public TodoName Name { get; private set; }

    public bool IsDone { get; private set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public static Todo Create(
        TodoId id,
        TodoName name,
        bool isDone,
        DateTime startDate,
        DateTime endDate)
    {
        var todo = new Todo()
        {
            Id = id,
            Name = name,
            IsDone = isDone,
            StartDate = startDate,
            EndDate = endDate
        };

        return todo;
    }
}
