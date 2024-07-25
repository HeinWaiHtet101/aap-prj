

namespace Todo.Application.Query.GetById;

public class GetTodoByIdValidation
    : AbstractValidator<GetTodoByIdQuery>
{
    public GetTodoByIdValidation()
    {
        RuleFor(x => x.id).NotEmpty().WithMessage("Search id should not be null");
    }
}
