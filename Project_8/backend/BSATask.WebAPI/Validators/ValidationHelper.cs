using FluentValidation;

namespace BSATask.WebAPI.Validators
{
    public static class ValidationHelper
    {
        public static IRuleBuilderOptions<T, int> ValidateForeignIds<T>(this IRuleBuilder<T, int> ruleBuilder, string propertyName)
        {
            return ruleBuilder
                .NotNull()
                .GreaterThan(0)
                    .WithMessage($"{propertyName} must be greater than 0");
        }

        public static IRuleBuilderOptions<T, string> ValidateNameOrDescription<T>(this IRuleBuilder<T, string> ruleBuilder, string propertyName)
        {
            return ruleBuilder
                .NotNull()
                .NotEmpty()
                    .WithMessage($"{propertyName} cannot be empty");
        }

        public static IRuleBuilderOptions<T, DateTime> ValidateDateTime<T>(this IRuleBuilder<T, DateTime> ruleBuilder, string propertyName)
        {
            return ruleBuilder
                .NotNull()
                .Must(date => date != default)
                    .WithMessage("Must be date")
                .GreaterThan(dt => DateTime.UtcNow)
                    .WithMessage($"{propertyName} must be after now");
        }
    }
}
