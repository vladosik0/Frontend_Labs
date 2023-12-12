using BSATask.DAL.Models.Tasks;
using FluentValidation;

namespace BSATask.WebAPI.Validators.TaskValidator
{
    public class TaskEditValidator : AbstractValidator<TaskEditDto>
    {
        public TaskEditValidator()
        {
            RuleFor(pc => pc.ProjectId)
                .ValidateForeignIds(nameof(TaskEditDto.ProjectId));

            RuleFor(pc => pc.PerformerId)
                .ValidateForeignIds(nameof(TaskEditDto.PerformerId));

            RuleFor(pc => pc.Name)
                .ValidateNameOrDescription(nameof(TaskEditDto.Name));

            RuleFor(pc => pc.Description)
                .ValidateNameOrDescription(nameof(TaskEditDto.Description));

            RuleFor(pc => pc.State)
                .IsInEnum()
                    .WithMessage("Task state must be between 0 and 3");
        }
    }
}
