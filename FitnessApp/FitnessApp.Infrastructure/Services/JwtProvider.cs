using System;
using System.IdentityModel.Tokens.Jwt;
using FitnessApp.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace FitnessApp.Infrastructure.Services;

public class JwtProvider
{
	public JwtProvider()
	{
	}
	public string GenerateToken(User user)
	{
		var credentials=new SigningCredentials(new SymmetricSecurityKey())
		var token=new JwtSecurityToken()

	}
}

