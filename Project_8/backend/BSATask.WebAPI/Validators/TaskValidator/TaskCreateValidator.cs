using BSATask.DAL.Models.Tasks;
using FluentValidation;

namespace BSATask.WebAPI.Validators.TaskValidator
{
    public class TaskCreateValidator : AbstractValidator<TaskCreateDto>
    {
        public TaskCreateValidator()
        {
            RuleFor(pc => pc.ProjectId)
                .ValidateForeignIds(nameof(TaskCreateDto.ProjectId));

            RuleFor(pc => pc.PerformerId)
                .ValidateForeignIds(nameof(TaskCreateDto.PerformerId));

            RuleFor(pc => pc.Name)
                .ValidateNameOrDescription(nameof(TaskCreateDto.Name));

            RuleFor(pc => pc.Description)
                .ValidateNameOrDescription(nameof(TaskCreateDto.Description));

            RuleFor(pc => pc.State)
                .IsInEnum()
                    .WithMessage("Task state must be between 0 and 3");
        }
    }
}
