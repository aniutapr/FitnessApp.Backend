using System;
namespace FitnessApp.Domain.Entities;

public class JwtOptions
{
	public string SecretKey { get; set; } = string.Empty;
	public int ExpiresHours { get; set; }
}