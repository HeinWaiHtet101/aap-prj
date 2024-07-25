
namespace Todo.Domain.ValueObjects;

public record TodoName
{
    private const int DefaultLength = 100;
    public string Value { get; }
    private TodoName(string value) => Value = value;
    public static TodoName Of(string value)
    {
        ArgumentException.ThrowIfNullOrEmpty(value);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Length, DefaultLength);

        return new TodoName(value);
    }
}
