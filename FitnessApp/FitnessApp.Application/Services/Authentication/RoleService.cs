using FitnessApp.Contracts.Interfaces.Services;
using FitnessApp.Domain.Entities;

namespace FitnessApp.Application.Services
{
    public class RoleService:IRoleService
	{
		public RoleService()
		{
		}

        public Task<Role> GetRoleByName(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}