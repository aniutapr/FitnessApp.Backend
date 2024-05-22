using FitnessApp.Application;
using FluentValidation;

namespace FitnessApp.Api.Validators
{
    public class ExerciseValidator : AbstractValidator<ExcersiseDto>
    {
        public ExerciseValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.SuggestedRepeats).GreaterThan(0);
            RuleFor(x => x.SuggestedWeight).GreaterThan(0);
        }
    }
}