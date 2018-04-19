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



            new Item
            {
                Id = Guid.NewGuid().ToString(),
                Text = "Ricotta strawberry French toast",
                Description = "30 min  2 Servings   *Easy",
                BriefDescribtion = "Give your French toast a summer makeover with fresh berries, lashings of ricotta, honey and mint ",
                Ingrediants = new string[] {"1 Large Egg, beaten",
                    "300ml milk",
                    "1 tbsp vanilla extract",
                    "4 slices thick-cut white bread",
                    "2 tbsp butter",
                    "60g ricotta",
                    "2 tbsp honey",
                    "100g strawberries, some sliced, some halved",
                    "2 mint sprigs, leaves picked",

                },
                steps = new string[]{ "In a wide dish, whisk the egg, milk and vanilla together. " +
                        "Coat one side of the bread slices in the liquid, then carefully flip them over" +
                        " and leave them to soak for 1-2 mins.",
                    "Melt 1 tbsp of the butter in a large non-stick pan over a medium heat and add two " +
                        "slices of bread. Cook for 5 mins or until golden, then turn to cook the other side" +
                        " for another 5 mins. Transfer to a plate and cook the other two slices in the rest of the butter.",
                        "Mix well and add sugar to taste . Mix everything together in the food processor",
                    "Halve the toast on the diagonal and spread each slice with the ricotta. Drizzle over the honey and a pinch " +
                        "of flaky sea salt, and arrange some sliced strawberries in a fan across the toast. Decorate the plate with the halved strawberries and mint.",

                    },
                Difficulty = "Easy",
                PrepTime = 10,
                CookTime = 20,

                ServingSize = 2,
                ReadyTime = 30,
                picture = UIKit.UIImage.FromBundle("toast")
            },

                new Item
            {
                Id = Guid.NewGuid().ToString(),
                    Text = "Glazed salmon with green bean & bulgur salad",
                Description = "30 min  2 Servings   *Easy",
                    BriefDescribtion = "Fresh citrus flavours turn a salmon fillet into a special meal",
                    Ingrediants = new string[] {"140g bulgur wheat",
                        "1 tbsp olive oil",
                        "2 skinless salmon fillets",
                        "6 spring onions, sliced",
                        "juice and zest ½ lemon",
                        "1 tbsp clear honey",
                        "juice 1 orange, plus 1 tsp zest",
                        "200g trimmed fine green beans",
                   

                },
                    steps = new string[]{ "Cook the bulgur wheat following pack instructions. " +
                        "Heat the olive oil in a frying pan over a medium heat. Add the salmon fillets " +
                        "and cook for 3 mins on each side. Stir in the spring onions and cook for 1 min. " +
                        "Add lemon juice, honey, orange juice and zest to the pan and bubble for 1 min more " +
                        "to make a sauce.",
                        "Meanwhile, boil the green beans for 4 mins or until tender. Drain. Stir the " +
                        "bulgur wheat with a fork, mixing in the green beans, lemon zest and a little of " +
                        "the sauce. Serve the salmon on a bed of bulgur and beans, with the rest of the sauce spooned over.",
                    

                    },
                Difficulty = "Easy",
                PrepTime = 10,
                CookTime = 15,

                ServingSize = 2,
                ReadyTime = 25,
                picture = UIKit.UIImage.FromBundle("salmon")
            },

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
