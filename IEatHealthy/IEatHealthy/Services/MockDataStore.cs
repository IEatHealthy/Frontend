using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEatHealthy
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var _items = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(),
                    Text = "Strawberry Vanilla Pancakes",
                    Description="20 min  8 Servings   *Easy",
                    BriefDescribtion="Very sweet and easy to prepare pancakes",
                    Ingrediants=new string[]{"12 Strawberry","1 Vanilla extract", "8 eggs","Sugar Powder","Butter"},
                    steps=new string[]{ "Prepare the pancakes  by mixing the eggs with the butter",
                        "Add vanilla and milk to the mixture",
                        "Mix well and add sugar to taste . Mix everything together in the food processor",
                        "Add butter to a flat iron pancakes pain. Cook it until it’s golden",
                        "Chop the strawberries and add it to the pancake",
                        "Add sugar powder and serve"
                    },
                    Difficulty="Easy",
                    PrepTime=5,
                    CookTime=5,

                    ServingSize=8,
                    ReadyTime=20,
                    picture=UIKit.UIImage.FromBundle ("pancake")},
                

            };

            foreach (Item item in _items)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

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
