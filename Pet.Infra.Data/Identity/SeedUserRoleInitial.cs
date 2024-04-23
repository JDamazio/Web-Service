using Microsoft.AspNetCore.Identity;
using Pet.Domain.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Infra.Data.Identity
{
	public class SeedUserRoleInitial : ISeedUserRoleInitial
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public void SeedUsers()
		{
			if(_userManager.FindByEmailAsync("Admin@admin").Result == null)
			{
				ApplicationUser user = new ApplicationUser();
				user.UserName = "Admin@admin";
				user.Email = "Admin@admin";
				user.NormalizedUserName = "ADMIN@ADMIN";
				user.NormalizedEmail = "ADMIN@ADMIN";
				user.EmailConfirmed = true;
				user.LockoutEnabled = false;
				user.SecurityStamp = Guid.NewGuid().ToString();

				IdentityResult result = _userManager.CreateAsync(user,$"Admin@{DateTime.Now.Year}").Result;

				if (result.Succeeded)
				{
					_userManager.AddToRoleAsync(user, "Admin").Wait();
				}
			}
		}

		public void SeedRoles()
		{
			if (!_roleManager.RoleExistsAsync("Admin").Result)
			{
				IdentityRole role = new IdentityRole();
				role.Name = "Admin";
				role.NormalizedName = "ADMIN";
				IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
			}

			if (!_roleManager.RoleExistsAsync("User").Result)
			{
				IdentityRole role = new IdentityRole();
				role.Name = "User";
				role.NormalizedName = "USER";
				IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
			}
		}
	}
}
