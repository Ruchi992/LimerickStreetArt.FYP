using System;
using System.Collections.Generic;
using System.Text;

namespace LimerickStreetArt.MySQL.UnitTests
{
	class Test
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


			int id = 2;
			Console.WriteLine($"Searching for user matching Id{id}");
			var getByid = userAccountRepositoryClass.GetById(id);
			Console.WriteLine(getByid.Username);


			Console.WriteLine($"get all users");

			var userAccounts = userAccountRepositoryClass.GetUserAccounts();

			foreach (var userAccount in userAccounts)
			{
				Console.WriteLine(userAccount.Username);
				
			}

		}
	}
}
