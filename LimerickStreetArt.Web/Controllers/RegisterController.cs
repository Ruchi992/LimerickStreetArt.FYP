using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using LimerickStreetArt.Repository;

namespace LimerickStreetArt.Web.Controllers
{
	public class RegisterController : Controller
	{
		public object StatusMessage { get; private set; }
		private readonly UserAccountRepository userAccountRepository;
		protected void CreateUser_Click(object sender, EventArgs e)
		{
			// Default UserStore constructor uses the default connection string named: DefaultConnection
			var userStore = new UserStore<IdentityUser>();
			var manager = new UserManager<IdentityUser>(userStore);

			var user = new IdentityUser() { UserName = UserName.Text };
			IdentityResult result = manager.Create(user, Password.Text);

			if (result.Succeeded)
			{
				StatusMessage.Text = string.Format("User {0} was created successfully!", user.UserName);
			}
			else
			{
				StatusMessage.Text = result.Errors.FirstOrDefault();
			}
		}
	}
}
