using Microsoft.AspNetCore.Identity;
using shop.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Web.Helpers
{
	public interface IUserHelper
	{
		// recordar que el asyn es parasaber si el metodo es asynctrono
		//le paso el email y me devuelve el usuario completo
		Task<User> GetUserByEmailAsync(string email);

		//aqui me devuelve si pudo hacer el logueo o si no pudo me muestra porque no pudo
		Task<IdentityResult> AddUserAsync(User user, string password);
	}

}
