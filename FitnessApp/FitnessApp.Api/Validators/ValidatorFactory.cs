using FitnessApp.Application;
using FitnessApp.Contracts.Interfaces.Services;

namespace FitnessApp.Api.Validators;

public class ValidatorFactory : IValidatorFactory
{
    public IValidator<T> GetValidator<T>()
    {
        if (typeof(T) == typeof(ExcersiseDto))
        {
            return new ExerciseValidator() as IValidator<T>;
        }
        return null;
    }
}