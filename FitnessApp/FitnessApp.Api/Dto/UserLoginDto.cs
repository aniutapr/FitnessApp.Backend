using System;
namespace FitnessApp.Api.Dto
{
	public class UserLoginDto
	{
		public UserLoginDto()
		{
		}
		public string Email { get; set; }
        public string Password { get; set; }
    }
}

