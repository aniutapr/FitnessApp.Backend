using System;
namespace FitnessApp.Domain.Entities;

public class Role
{
	public int Id { get; set; }
	public string Name { get; set; }
	public ICollection<Permission> Permissions { get; set; }
	public ICollection<User> Users { get; set; }
}