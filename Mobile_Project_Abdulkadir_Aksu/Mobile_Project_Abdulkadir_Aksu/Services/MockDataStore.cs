using Mobile_Project_Abdulkadir_Aksu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Project_Abdulkadir_Aksu.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Wild boars", Description="This is an item description.",URL="https://restlessbackpacker.com/how-to-survive-a-wild-boar-attack/" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Deer", Description="This is an item description.",URL="https://goneoutdoors.com/fend-off-charging-deer-4464419.html" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fox", Description="This is an item description.",URL="https://www.humanesociety.org/resources/what-do-about-foxes" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Wolf", Description="This is an item description.",URL="https://restlessbackpacker.com/how-to-survive-a-wolf-attack/" }
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