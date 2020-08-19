using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimerickStreetArtApp.Models;

namespace LimerickStreetArtApp.Services
{
	public class MockDataStore : IDataStore<Item>
	{
		readonly List<Item> items;

		public MockDataStore()
		{
			items = new List<Item>()
			{
				new Item { Id = Guid.NewGuid().ToString(), Username = "First UserName", Password="This is an item description." },
				new Item { Id = Guid.NewGuid().ToString(), Username = "LogingPage", Password="This is an item description." },
				new Item { Id = Guid.NewGuid().ToString(), Username = "Third item", Password="This is an item description." },
				new Item { Id = Guid.NewGuid().ToString(), Username = "Fourth item", Password="This is an item description." },
				new Item { Id = Guid.NewGuid().ToString(), Username = "Fifth item", Password="This is an item description." },
				new Item { Id = Guid.NewGuid().ToString(), Username = "Sixth item", Password="This is an item description." }
			};
		}

		public async Task<bool> AddItemAsync(Item item)
		{
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(Item item)
		{
			var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(oldItem);
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(string id)
		{
			var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
			items.Remove(oldItem);

			return await Task.FromResult(true);
		}

		public async Task<Item> GetItemAsync(string id)
		{
			return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
		{
			return await Task.FromResult(items);
		}
	}
}