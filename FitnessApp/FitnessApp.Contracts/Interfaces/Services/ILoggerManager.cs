using System;
namespace FitnessApp.Contracts.Interfaces.Services;

public interface ILoggerManager
{
    void LogInformation(string message);
    void LogWarning(string message);
    void LogError(string message);
    void LogException(Exception ex);
}