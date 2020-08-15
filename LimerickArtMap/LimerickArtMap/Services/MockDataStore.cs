using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimerickStreetArt.MobileForms.Services
{
	public class MockDataStore : IDataStore<StreetArt>
	{
		readonly List<StreetArt> items;

		public MockDataStore()
		{
			items = new List<StreetArt>()
			{
			 new StreetArt
				{
				 Id=1,
					GpsLatitude = 23.08769f,
					GpsLongitude = 23.00000f,
					Title = "Jim version",
					Timestamp = DateTime.Now,
					Street = "Evergreen Terrrace",
					Image = "Image",
					UserAccountId = 2,
				},
			 new StreetArt
				{
				 Id=2,
					GpsLatitude = 23.08769f,
					GpsLongitude = 23.00000f,
					Title = "Jim version",
					Timestamp = DateTime.Now,
					Street = "Evergreen Terrrace",
					Image = "Image",
					UserAccountId = 2,
				},
			 new StreetArt
				{
				 Id=3,
					GpsLatitude = 23.08769f,
					GpsLongitude = 23.00000f,
					Title = "Jim version",
					Timestamp = DateTime.Now,
					Street = "Evergreen Terrrace",
					Image = "Image",
					UserAccountId = 2,
				},
			};
		}

		public async Task<bool> AddItemAsync(StreetArt item)
		{
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(StreetArt item)
		{
			var oldItem = items.Where((StreetArt arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(oldItem);
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(string id)
		{
			var oldItem = items.Where((StreetArt arg) => arg.Id.ToString() == id).FirstOrDefault();
			items.Remove(oldItem);

			return await Task.FromResult(true);
		}

		public async Task<StreetArt> GetItemAsync(string id)
		{
			return await Task.FromResult(items.FirstOrDefault(s => s.Id.ToString() == id));
		}

		public async Task<IEnumerable<StreetArt>> GetItemsAsync(bool forceRefresh = false)
		{
			return await Task.FromResult(items);
		}
	}
}