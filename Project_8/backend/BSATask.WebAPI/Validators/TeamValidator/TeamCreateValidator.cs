using BSATask.DAL.Models.Teams;
using FluentValidation;

namespace BSATask.WebAPI.Validators.TeamValidator
{
    public class TeamCreateValidator : AbstractValidator<TeamCreateDto>
    {
        public TeamCreateValidator()
        {
            RuleFor(pc => pc.Name)
                .ValidateNameOrDescription(nameof(TeamCreateDto.Name));
        }
    }
}
