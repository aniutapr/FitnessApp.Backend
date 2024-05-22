using System;
namespace FitnessApp.Contracts.Interfaces.Services
{
    public interface IValidatorFactory
    {
        IValidator<T> GetValidator<T>();
    }
}