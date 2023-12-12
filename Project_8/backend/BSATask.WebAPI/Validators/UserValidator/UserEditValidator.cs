using BSATask.DAL.Models.Users;
using FluentValidation;

namespace BSATask.WebAPI.Validators.UserValidator
{
    public class UserEditValidator : AbstractValidator<UserEditDto>
    {
        public UserEditValidator()
        {
            RuleFor(pc => pc.TeamId)
                .GreaterThan(0)
                    .WithMessage("Team id must be greater than 0");

            RuleFor(pc => pc.FirstName)
                .ValidateNameOrDescription(nameof(UserEditDto.FirstName));

            RuleFor(pc => pc.LastName)
                .ValidateNameOrDescription(nameof(UserEditDto.LastName));

            RuleFor(pc => pc.Email)
                .EmailAddress()
                    .WithMessage("Email has incorrect format");

            RuleFor(pc => pc.BirthDay)
                .NotNull()
                .InclusiveBetween(new DateTime(1920, 01, 01), new DateTime(DateTime.UtcNow.Year - 16, 01, 01))
                    .WithMessage($"BirthDay should be between 1920 and {DateTime.UtcNow.Year - 16}");
        }
    }
}
