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
		public void TestCreateAndDelete()
		{
			var newStreetArt = new StreetArt
			{

				GpsLatitude = 23.08769f,
				GpsLongitude = 23.00000f,
				Title = "Jim version",
				Timestamp = DateTime.Now,
				Street = "Evergreen Terrrace",
				Image = "Image",
				UserAccountId = 2,
			};
			sut.Create(newStreetArt);

			var streetArt = sut.GetById(newStreetArt.Id);

			Assert.AreEqual(streetArt.GpsLatitude, newStreetArt.GpsLatitude);
			Assert.AreEqual(streetArt.GpsLongitude, newStreetArt.GpsLongitude);
			Assert.AreEqual(streetArt.Title, newStreetArt.Title);
			//Assert.AreEqual(streetArt.Image, newStreetArt.Image);
			Assert.AreEqual(streetArt.UserAccountId, streetArt.UserAccountId);
			Assert.AreEqual(streetArt.Id, streetArt.Id);


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
		public void TestGetStreetArtList()
		{
			var users = sut.GetStreetArtList();
			foreach (var userAccount in users)
			{
				Console.WriteLine(userAccount.Title);

			}
			Assert.IsNotNull(users);
		}
		[TestMethod]
		public void UpdateStreetArt()
		{

			int Id = 15;
			var streetArtEdit = sut.GetById(Id);

			streetArtEdit.GpsLatitude = 23.08769f;
			streetArtEdit.GpsLongitude = 23.00000f;
			streetArtEdit.Title = "Jim version";
			streetArtEdit.Timestamp = DateTime.Now;
			streetArtEdit.Street = "Evergreen Terrrace";
			streetArtEdit.Image = "Image";
			streetArtEdit.UserAccountId = 2;

			sut.Update(streetArtEdit);

			var streetArt = sut.GetById(streetArtEdit.Id);

			Assert.AreEqual(streetArt.GpsLongitude, streetArtEdit.GpsLongitude);
			Assert.AreEqual(streetArt.GpsLatitude, streetArtEdit.GpsLatitude);
			Assert.AreEqual(streetArt.Title, streetArtEdit.Title);
			Assert.AreEqual(streetArt.Street, streetArtEdit.Street);
			//Assert.AreEqual(streetArt.Image, streetArtEdit.Image);
			//Assert.AreEqual(streetArt.Timestamp, streetArtEdit.Timestamp);
			Assert.AreEqual(streetArt.UserAccountId, streetArtEdit.UserAccountId);
			Assert.AreEqual(streetArt.Id, streetArtEdit.Id);

		}
	}
}
