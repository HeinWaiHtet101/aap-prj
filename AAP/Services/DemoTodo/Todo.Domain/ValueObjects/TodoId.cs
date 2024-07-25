
namespace Todo.Domain.ValueObjects;

public record TodoId
{
    public Guid Value { get; }
    private TodoId(Guid value) => Value = value;
    public static TodoId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if(value == Guid.Empty)
        {
            throw new DomainException("Todo ID should not be empty");
        }

        return new TodoId(value);
    }
}
