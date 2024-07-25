

namespace Todo.Application.Command.Create;

public class CreateTodoValidation
    : AbstractValidator<CreateTodoCommand>
{
    public CreateTodoValidation()
    {
        RuleFor(x => x.name).NotEmpty().WithMessage("name should not be empty");
        RuleFor(x => x.startDate).NotEmpty().WithMessage("start date should not be null");
        RuleFor(x => x.endDate).NotEmpty().WithMessage("end date should not be null");
    }
}
