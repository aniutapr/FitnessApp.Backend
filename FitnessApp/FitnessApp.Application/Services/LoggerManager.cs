using System;
using FitnessApp.Contracts.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace FitnessApp.Application.Services;

public class LoggerManager : ILoggerManager
{
    private readonly ILogger<LoggerManager> _logger;

    public LoggerManager(ILogger<LoggerManager> logger)
    {
        _logger = logger;
    }

    public void LogInformation(string message)
    {
        _logger.LogInformation(message);
    }

    public void LogWarning(string message)
    {
        _logger.LogWarning(message);
    }

    public void LogError(string message)
    {
        _logger.LogError(message);
    }

    public void LogException(Exception ex)
    {
        _logger.LogError(ex, ex.Message);
    }
}