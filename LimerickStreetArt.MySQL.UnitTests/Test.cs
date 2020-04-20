using System;
using System.Collections.Generic;
using System.Text;

namespace LimerickStreetArt.MySQL.UnitTests
{
	internal class Test
	{
		public static void Main()
		{
			var databaseClass = new DatabaseClass
			{
				ConnectionString = "Server=localhost;Database=limerickstreetart;Uid=root;Password=;"
			};
			
			var userAccountRepositoryClass = new UserAccountRepositoryClass(databaseClass);



			String username = "admin", password = "letmein";
			Console.WriteLine($"GetUserAccountByCredentials Username:{username} and Password:{password}");
			var user1 = userAccountRepositoryClass.GetUserAccountByCredentials(username, password);
			Console.WriteLine(user1.Username);


			int id = 299;
			Console.WriteLine($"Searching for user matching Id{id}");
			var getByid = userAccountRepositoryClass.GetById(id);
			if(getByid== null)
				Console.WriteLine($"No user matching Id{id}");
			else
			Console.WriteLine(getByid.Username);


			Console.WriteLine($"get all users");
			var userAccounts = UserAccountRepositoryClass.

			var userAccounts = userAccountRepositoryClass.GetUserAccounts();

			foreach (var userAccount in userAccounts)
			{
				Console.WriteLine(userAccount.Username);
				
			}

		}
	}
}
