using BSATask.DAL.Models.Projects;
using FluentValidation;

namespace BSATask.WebAPI.Validators.ProjectValidator
{
    public class ProjectCreateValidator : AbstractValidator<ProjectCreateDto>
    {
        public ProjectCreateValidator()
        {
            RuleFor(pc => pc.AuthorId)
                .ValidateForeignIds(nameof(ProjectCreateDto.AuthorId));

            RuleFor(pc => pc.TeamId)
                .ValidateForeignIds(nameof(ProjectCreateDto.TeamId));

            RuleFor(pc => pc.Name)
                .ValidateNameOrDescription(nameof(ProjectCreateDto.Name));

            RuleFor(pc => pc.Description)
                .ValidateNameOrDescription(nameof(ProjectCreateDto.Description));

            RuleFor(pc => pc.Deadline)
                .ValidateDateTime(nameof(ProjectCreateDto.Deadline))
                .GreaterThan(dt => dt.CreatedAt)
                    .WithMessage("Deadline cannot be earlier than project created");

        }
    }
}
