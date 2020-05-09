namespace LimerickStreetArt.MySQL.UnitTests
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	[TestClass]
	public class UserAccountRepositoryClassTest
	{
		/// <summary>
		/// System Under Test (SUT)
		/// </summary>
		private UserAccountRepositoryClass sut;
		[TestInitialize]
		public void Initialize()
		{
			var databaseClass = new DatabaseClass
			{
				ConnectionString = AppSettings.ConnectionString
			};

			sut = new UserAccountRepositoryClass(databaseClass);
		}
		//[TestMethod]
		public void TestConstructor()
		{
			var databaseClass = new DatabaseClass
			{
				ConnectionString = "Server=localhost;Database=limerickstreetart;Uid=root;Password=;"
			};

			var userAccountRepositoryClass = new UserAccountRepositoryClass(databaseClass);
			Assert.IsNotNull(userAccountRepositoryClass);
		}
		[TestMethod]
		public void TestGetUserAccountByCredentials1()
		{
			String username = "Admin", password = "letmein";
			Console.WriteLine($"GetUserAccountByCredentials Username:{username} and Password:{password}");
			var user = sut.GetUserAccountByCredentials(username, password);
			Console.WriteLine(user.Username);

			Assert.AreEqual(user.Username, username);
		}
		[TestMethod]
		public void TestGetUserAccountByCredentials2()
		{
			String username = "Test", password = "letmein";
			Console.WriteLine($"GetUserAccountByCredentials Username:{username} and Password:{password}");
			var user = sut.GetUserAccountByCredentials(username, password);
			Console.WriteLine(user.Username);

			Assert.AreEqual(user.Username, username);
		}
		[TestMethod]
		public void TestCreateAndDelete()
		{
			UserAccount newUserAccount = new UserAccount
			{
				AccessLevel = 2,
				Email = "letmien2aa@emialo.com" + DateTime.Now.ToString(),
				Password = "letmien",
				Username = "TestCreateUser12" + DateTime.Now.ToString(),
			};
			sut.Create(newUserAccount);

			var user = sut.GetById(newUserAccount.Id);

			Assert.AreEqual(user.Username, newUserAccount.Username);
			Assert.AreEqual(user.Email, newUserAccount.Email);
			Assert.AreEqual(user.Password, newUserAccount.Password);

			sut.Delete(newUserAccount);
		}
		[TestMethod]
		public void TestGetById()
		{
			int id = 2;
			var user = sut.GetById(id);

			Assert.AreEqual(user.Id, id);
		}
		[TestMethod]
		public void TestGetByNonexistingId()
		{
			int id = 2666;
			var user = sut.GetById(id);

			Assert.IsNull(user);
		}
		[TestMethod]
		public void TestGetUserAccounts()
		{
			var users = sut.GetUserAccounts();
			foreach (var userAccount in users)
			{
				Console.WriteLine(userAccount.Username);

			}
			Assert.IsNotNull(users);
		}
		[TestMethod]
		public void TestGetActiveUserAccounts()
		{
			var users = sut.GetActiveUserAccounts();
			Assert.IsNotNull(users);
			foreach (var userAccount in users)
			{
				Assert.IsTrue(userAccount.Active);
			}
		}
		[TestMethod]
		public void TestUpdateUserAccount()
		{
			int id = 16;
			var userEdit = sut.GetById(id);

			userEdit.Email = "letmie1224n@emialo.com";
			userEdit.Password = "letmien";
			userEdit.Username = "TestCreateUser42";
			userEdit.AccessLevel = 1;
			userEdit.Active = true;

			sut.Update(userEdit);

			var user = sut.GetById(userEdit.Id);

			Assert.AreEqual(user.Username, userEdit.Username);
			Assert.AreEqual(user.Email, userEdit.Email);
			Assert.AreEqual(user.Password, userEdit.Password);
			Assert.AreEqual(user.AccessLevel, userEdit.AccessLevel);
			Assert.AreEqual(user.Active, userEdit.Active);

		}
	}
}
