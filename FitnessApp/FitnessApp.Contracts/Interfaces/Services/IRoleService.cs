using System;
using FitnessApp.Domain.Entities;

namespace FitnessApp.Contracts.Interfaces.Services
{
	public interface IRoleService
	{
        Task<Role> GetRoleByName(string roleName);
    }
}

