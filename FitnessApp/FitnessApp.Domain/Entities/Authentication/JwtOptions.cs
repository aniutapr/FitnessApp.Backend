using System;
namespace FitnessApp.Domain.Entities;

public class JwtOptions
{
	public string SecretKey { get; set; } 
	public int ExpiresHours { get; set; } 
}