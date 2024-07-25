
namespace Todo.Application.Dtos;

public record TodoDto(
    Guid id,
    string name,
    bool isDone,
    DateTime startDate,
    DateTime endDate);