using BSATask.DAL.Models.Users;
using FluentValidation;

namespace BSATask.WebAPI.Validators.UserValidator
{
    public class UserCreateValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateValidator()
        {
            RuleFor(pc => pc.TeamId)
                .GreaterThan(0)
                    .WithMessage("Team id must be greater than 0");

            RuleFor(pc => pc.FirstName)
                .ValidateNameOrDescription(nameof(UserCreateDto.FirstName));

            RuleFor(pc => pc.LastName)
                .ValidateNameOrDescription(nameof(UserCreateDto.LastName));

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
