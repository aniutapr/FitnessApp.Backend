
using System;
namespace FitnessApp.Api.Dto
{
	public class UserRegisterDto
	{
		public UserRegisterDto()
		{
		}
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}