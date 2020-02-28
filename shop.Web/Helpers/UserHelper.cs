﻿
namespace shop.Web.Helpers
{
	using System.Threading.Tasks;
	using Data.Entities;
	using Microsoft.AspNetCore.Identity;

	public class UserHelper : IUserHelper
	{// con esta clase es que voy a configurar el userManager...
		private readonly UserManager<User> userManager;

		public UserHelper(UserManager<User> userManager)
		{
			this.userManager = userManager;
		}

		public async Task<IdentityResult> AddUserAsync(User user, string password)
		{
			return await this.userManager.CreateAsync(user, password);
		}

		public async Task<User> GetUserByEmailAsync(string email)
		{
			return await this.userManager.FindByEmailAsync(email);
			
		}
	}


}
