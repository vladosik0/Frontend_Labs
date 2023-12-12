using BSATask.DAL.Models.Teams;
using FluentValidation;

namespace BSATask.WebAPI.Validators.TeamValidator
{
    public class TeamEditValidator : AbstractValidator<TeamEditDto>
    {
        public TeamEditValidator()
        {
            RuleFor(pc => pc.Name)
                .ValidateNameOrDescription(nameof(TeamCreateDto.Name));
        }
    }
}
