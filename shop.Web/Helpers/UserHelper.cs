
namespace shop.Web.Helpers
{
	using Data.Entities;
	using Microsoft.AspNetCore.Identity;
	using shop.Web.Models;
	using System.Threading.Tasks;

	public class UserHelper : IUserHelper
	{// con esta clase es que voy a configurar el userManager...
		private readonly UserManager<User> userManager;
		private readonly SignInManager<User> signInManager;

		public UserHelper(UserManager<User> userManager, SignInManager<User> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		public async Task<IdentityResult> AddUserAsync(User user, string password)
		{
			return await this.userManager.CreateAsync(user, password);
		}

		public async Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword)
		{
			return await this.userManager.ChangePasswordAsync(user, oldPassword, newPassword);
		}

		public async Task<User> GetUserByEmailAsync(string email)
		{
			return await this.userManager.FindByEmailAsync(email);

		}

		public async Task<SignInResult> LoginAsync(LoginViewModel model)
		{
			return await this.signInManager.PasswordSignInAsync(
				model.Username,
				model.Password,
				model.RememberMe,
						false);// este parametro de false es por si quiere que me bloquee la cuenta cuando se equivoque
		}

		public async Task LogoutAsync()
		{
			await this.signInManager.SignOutAsync();
		}

		public  async Task<IdentityResult> UpdateUserAsync(User user)
		{
			return await this.userManager.UpdateAsync(user);
		}
	}


}
