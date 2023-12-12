using BSATask.DAL.Models.Projects;
using FluentValidation;

namespace BSATask.WebAPI.Validators.ProjectValidator
{
    public class ProjectEditValidator : AbstractValidator<ProjectEditDto>
    {
        public ProjectEditValidator()
        {
            RuleFor(pc => pc.AuthorId)
                .ValidateForeignIds(nameof(ProjectEditDto.AuthorId));

            RuleFor(pc => pc.TeamId)
                .ValidateForeignIds(nameof(ProjectEditDto.TeamId));

            RuleFor(pc => pc.Name)
                .ValidateNameOrDescription(nameof(ProjectEditDto.Name));

            RuleFor(pc => pc.Description)
                .ValidateNameOrDescription(nameof(ProjectEditDto.Description));
        }
    }
}
