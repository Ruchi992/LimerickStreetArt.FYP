using System;
using System.Collections.Generic;
using System.Text;

namespace LimerickStreetArt.MySQL.UnitTests
{
	class Test
	{
		public static void Main()
		{
			DatabaseClass databaseClass = new DatabaseClass();
			databaseClass.ConnectionString = "";
			UserAccountRepositoryClass userAccountRepositoryClass = new UserAccountRepositoryClass(databaseClass);

			var userAccounts = userAccountRepositoryClass.SelectAll();

			foreach (var userAccount in userAccounts)
			{
				Console.WriteLine(userAccount.Username);
			}
		}
	}
}
