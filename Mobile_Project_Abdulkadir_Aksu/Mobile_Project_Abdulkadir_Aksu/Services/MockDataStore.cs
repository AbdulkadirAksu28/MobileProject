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
                new Item { Id = Guid.NewGuid().ToString(), Text = "Wild boars", Description="Wild boar are the pig that is thought to have been domesticated over a period of thousands of years, to give us our familiar domestic pig. ",URL="https://restlessbackpacker.com/how-to-survive-a-wild-boar-attack/" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Deer", Description="The roe deer is a relatively small deer, with a body length of 95–135 cm (3 ft 1 in–4 ft 5 in) throughout its range, and a shoulder height of 63–67 cm (2 ft 1 in–2 ft 2 in), and a weight of 15–35 kg (35–75 lb).",URL="https://goneoutdoors.com/fend-off-charging-deer-4464419.html" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fox", Description="Foxes are generally smaller than some other members of the family Canidae such as wolves and jackals, while they may be larger than some within the family, such as Raccoon dogs. ",URL="https://www.humanesociety.org/resources/what-do-about-foxes" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Wolf", Description="The wolf is the largest extant member of the Canidae family, and is further distinguished from coyotes and jackals by a broader snout, shorter ears, a shorter torso and a longer tail.",URL="https://restlessbackpacker.com/how-to-survive-a-wolf-attack/" }
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