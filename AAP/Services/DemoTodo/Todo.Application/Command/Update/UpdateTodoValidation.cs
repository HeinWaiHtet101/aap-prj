
namespace Todo.Application.Command.Update;

public class UpdateTodoValidation
    : AbstractValidator<UpdateTodoCommand>
{
    public UpdateTodoValidation()
    {
        RuleFor(x => x.id).NotEmpty().WithMessage("Update Id should not be null");
        RuleFor(x => x.name).NotEmpty().WithMessage("Update name should not be null");
        RuleFor(x => x.startDate).NotEmpty().WithMessage("Update Date should not be null");
        RuleFor(x => x.endDate).NotNull().WithMessage("Update End date should not be null");
    }
}
