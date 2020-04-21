namespace LimerickStreetArt.MySQL.UnitTests
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	[TestClass]
	public class StreetArtRepositoryClassTest
	{
		/// <summary>
		/// System Under Test (SUT)
		/// </summary>
		private StreetArtRepositoryClass sut;
		[TestInitialize]
		public void Initialize()
		{
			var databaseClass = new DatabaseClass
			{
				ConnectionString = AppSettings.ConnectionString
			};

			sut = new StreetArtRepositoryClass(databaseClass);
		}
		//[TestMethod]
		public void TestConstructor()
		{
			var databaseClass = new DatabaseClass
			{
				ConnectionString = "Server=localhost;Database=limerickstreetart;Uid=root;Password=;"
			};

			var streetartRepositoryClass = new StreetArtRepositoryClass(databaseClass);
			Assert.IsNotNull(streetartRepositoryClass);
		}
		[TestMethod]
		public void TestCreate()
		{
			var newStreetArt = new StreetArt
			{

				GpsLatitude = 2308769,
				GpsLongitude = 2300000,
				Title = "Jim version",
				Timestamp = DateTime.Now,
				Image = "Image",
				UserAccountId = 2,
			};
			sut.Create(newStreetArt);

			var streetArt = sut.GetById(newStreetArt.Id);

			Assert.AreEqual(streetArt.GpsLatitude, newStreetArt.GpsLatitude);
			Assert.AreEqual(streetArt.GpsLongitude, newStreetArt.GpsLongitude);
			Assert.AreEqual(streetArt.Title, newStreetArt.Title);
			Assert.AreEqual(streetArt.Image, newStreetArt.Image);
			Assert.AreEqual(streetArt.UserAccountId, streetArt.UserAccountId);


			sut.Delete(newStreetArt);
		}
		[TestMethod]
		public void TestGetById()
		{
			int id = 3;
			var streetArt = sut.GetById(id);

			Assert.IsNotNull(streetArt);
		}
		[TestMethod]
		public void TestGetByNonexistingId()
		{
			int id = 2666;
			var streetArt = sut.GetById(id);

			Assert.IsNull(streetArt);
		}
		[TestMethod]
		public void TestDelete()
		{
			int id = 8;
			var streetArt = sut.GetById(id);
			Assert.IsNull(streetArt);

			sut.Delete(streetArt);


			var deletedStreetArt = sut.GetById(id);

			Assert.IsNull(deletedStreetArt);
		}
		[TestMethod]
		public void TestGetStreetArtList()
		{
			var users = sut.GetStreetArtList();
			foreach (var userAccount in users)
			{
				Console.WriteLine(userAccount.Title);

			}
			Assert.IsNotNull(users);
		}
	}
}
