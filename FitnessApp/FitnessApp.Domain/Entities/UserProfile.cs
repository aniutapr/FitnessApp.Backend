using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Domain.Entities;

public class UserProfile
{
	[Key]
	public Guid UserId { get; set; }
}