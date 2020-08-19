using LimerickStreetArtApp.Helpers;
using LimerickStreetArtApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LimerickStreetArtApp.Services
{
	internal class ApiServices
	{


		public async Task<bool> RegisterUserAsync(
			string email, string password, string username, DateTime DateOfBirth, int AccessLevel)
		{
			var client = new HttpClient();

			var model = new UserAccount
			{
				Email = email,
				Password = password,
				Username = username,
				DateOfBirth = DateOfBirth,
				AccessLevel = AccessLevel

			};

			var json = JsonConvert.SerializeObject(model);

			HttpContent httpContent = new StringContent(json);

			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			var response = await client.PostAsync(
				Constants.BaseApiAddress + "api/UserRegisteration", httpContent);

			if (response.IsSuccessStatusCode)
			{
				return true;
			}

			return false;
		}

		public async Task<string> LoginAsync(string userName, string password)
		{
			var keyValues = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("username", userName),
				new KeyValuePair<string, string>("password", password),

			};

			var request = new HttpRequestMessage(
				HttpMethod.Post, Constants.BaseApiAddress + "Token");

			request.Content = new FormUrlEncodedContent(keyValues);

			var client = new HttpClient();
			var response = await client.SendAsync(request);

			var content = await response.Content.ReadAsStringAsync();

			JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(content);

			var accessTokenExpiration = jwtDynamic.Value<DateTime>(".expires");
			var accessToken = jwtDynamic.Value<string>("access_token");

			Settings.AccessTokenExpirationDate = accessTokenExpiration;

			Debug.WriteLine(accessTokenExpiration);

			Debug.WriteLine(content);

			return accessToken;
		}

		public async Task<List<UserAccount>> GetIdeasAsync(string accessToken)
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
				"Bearer", accessToken);

			var json = await client.GetStringAsync(Constants.BaseApiAddress + "api/Registeration");

			var user = JsonConvert.DeserializeObject<List<UserAccount>>(json);

			return user;
		}
	}
}
