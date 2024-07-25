
namespace Todo.Application.Command.Delete;

internal class DeleteTodoValidation
    : AbstractValidator<DeleteTodoCommand>
{
    public DeleteTodoValidation()
    {
        RuleFor(x => x.id).NotEmpty().WithMessage("Delete key should be added");
    }
}
