//using LimerickStreetArt.UserAccount;
using LimerickStreetArt.MobileForms;
using LimerickStreetArt.MobileForms.Models;
using LimerickStreetArtApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace LimerickStreetArt.Services
{
	public class ApiServiceMockComponents : ApiService
	{
		public object Constants { get; private set; }

		public async Task<bool> RegisterAsync(
			string email,
			string username,
			DateTime dateOfBirth,
			string password,
			string passwordConfirmation)
		{
			var client = new HttpClient();
			var model = new
			{
				Password = password,
				ReconformPassword = passwordConfirmation,
				Email = email,
				Username = username,
				DateOfBirth = dateOfBirth,
			};

			var jsonObject = JsonConvert.SerializeObject(model);
			HttpContent content = new StringContent(jsonObject);

			return true; ;
		}
		public async Task LoginAsync(string Username, string Password)
		{
			var keyValues = new List<KeyValuePair<string, string>>
		 {
			 new KeyValuePair<string, string>(Username,Username),
			 new KeyValuePair<string,string>(Password,Password),
		 };
			var request = new HttpRequestMessage(HttpMethod.Post, AppUrls.login)
			{
				Content = new FormUrlEncodedContent(keyValues)
			};
			var client = new HttpClient();
			var response = await client.SendAsync(request);
			Debug.WriteLine(await response.Content.ReadAsStringAsync());
		}
		public async Task<List<StreetArt>> SearchLocationAsync(string keyword, string accessToken)
		{
			var streetArts = JsonConvert.DeserializeObject<List<StreetArt>>(streetArtJsonList);
			return streetArts;
		}
		private string streetArtJsonList = @"
[
    {
        ""id"": 1,

		""gpsLatitude"": 30.2234,
        ""gpsLongitude"": -97.7697,
        ""title"": ""1"",
        ""street"": ""1"",
        ""timestamp"": ""0001-01-01T00:00:00"",
        ""image"": ""1.jpg"",
        ""userAccountId"": 1

	},
    {
        ""id"": 17,
        ""gpsLatitude"": 52.666252,
        ""gpsLongitude"": -8.625027,
        ""title"": ""Garden View"",
        ""street"": ""Evergreen Terrrace"",
        ""timestamp"": ""2020-05-09T00:32:25"",
        ""image"": ""Image"",
        ""userAccountId"": 2
    },
    {
        ""id"": 18,
        ""gpsLatitude"": 52.66129,
        ""gpsLongitude"": -8.629269,
        ""title"": ""River side"",
        ""street"": ""Evergreen Terrrace"",
        ""timestamp"": ""2020-05-09T00:35:47"",
        ""image"": ""Image"",
        ""userAccountId"": 2
    },
    {
        ""id"": 32,
        ""gpsLatitude"": 56.8964,
        ""gpsLongitude"": -67.467,
        ""title"": ""River Side"",
        ""street"": ""Limerick"",
        ""timestamp"": ""2020-05-29T11:39:05"",
        ""image"": ""32.jpg"",
        ""userAccountId"": 1
    }
]";
		private List<StreetArt> list = new List<StreetArt>()
		{
			 new StreetArt
			{
				Id = 1,
				GpsLatitude = 23.08769f,
				GpsLongitude = 23.00000f,
				Title = "Jim version",
				Timestamp = DateTime.Now,
				Street = "Evergreen Terrrace",
				Image = "Image",
				UserAccountId = 2
			},
			  new StreetArt
			{
				Id = 2,
				GpsLatitude = 23.08769f,
				GpsLongitude = 23.00000f,
				Title = "Jim version",
				Timestamp = DateTime.Now,
				Street = "Evergreen Terrrace",
				Image = "Image",
				UserAccountId = 2
			},
			   new StreetArt
			{
				Id = 3,
				GpsLatitude = 23.08769f,
				GpsLongitude = 23.00000f,
				Title = "Jim version",
				Timestamp = DateTime.Now,
				Street = "Evergreen Terrrace",
				Image = "Image",
				UserAccountId = 2
			   },
		};
	}
}



