namespace LimerickStreetArt.MobileForms.Services
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.Net.Http;
	using System.Text;
	using System.Threading.Tasks;
	using Xamarin.Essentials;
	public class AzureDataStore : IDataStore<StreetArt>
	{
		readonly HttpClient client;
		IEnumerable<StreetArt> items;

		public AzureDataStore()
		{
			client = new HttpClient
			{
				BaseAddress = new Uri($"{App.AzureBackendUrl}/")
			};

			items = new List<StreetArt>();
		}

		bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
		public async Task<IEnumerable<StreetArt>> GetItemsAsync(bool forceRefresh = false)
		{
			if (forceRefresh && IsConnected)
			{
				var json = await client.GetStringAsync($"api/item");
				items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<StreetArt>>(json));
			}

			return items;
		}

		public async Task<StreetArt> GetItemAsync(string id)
		{
			if (id != null && IsConnected)
			{
				var json = await client.GetStringAsync($"api/item/{id}");
				return await Task.Run(() => JsonConvert.DeserializeObject<StreetArt>(json));
			}

			return null;
		}

		public async Task<bool> AddItemAsync(StreetArt item)
		{
			if (item == null || !IsConnected)
				return false;

			var serializedItem = JsonConvert.SerializeObject(item);

			var response = await client.PostAsync($"api/item", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

			return response.IsSuccessStatusCode;
		}

		public async Task<bool> UpdateItemAsync(StreetArt item)
		{
			if (item == null || item.Id == 0 || !IsConnected)
				return false;

			var serializedItem = JsonConvert.SerializeObject(item);
			var buffer = Encoding.UTF8.GetBytes(serializedItem);
			var byteContent = new ByteArrayContent(buffer);

			var response = await client.PutAsync(new Uri($"api/item/{item.Id}"), byteContent);

			return response.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteItemAsync(string id)
		{
			if (string.IsNullOrEmpty(id) && !IsConnected)
				return false;

			var response = await client.DeleteAsync($"api/item/{id}");

			return response.IsSuccessStatusCode;
		}
	}
}
