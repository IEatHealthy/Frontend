using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace IEatHealthy
{
    public class MockDataStore : IDataStore<Item>
    {
       
         


        List<Item> items;
        UserAccount MainUser = new UserAccount();
        public MockDataStore()
        {
            items = new List<Item>();
            var _items = new List<Item>
            {
                new Item { id = Guid.NewGuid().ToString(),
                    name = "Strawberry Vanilla Pancakes",
                  //  Description="20 min  8 Servings   *Easy",
                    description="Very sweet and easy to prepare pancakes",
                  //  ingredients=new List<IngredientItem>.Enumerator {"12 Strawberry","1 Vanilla extract", "8 eggs","Sugar Powder","Butter"},
                    steps=new List<string>{ "Prepare the pancakes  by mixing the eggs with the butter",
                        "Add vanilla and milk to the mixture",
                        "Mix well and add sugar to taste . Mix everything together in the food processor",
                        "Add butter to a flat iron pancakes pain. Cook it until it’s golden",
                        "Chop the strawberries and add it to the pancake",
                        "Add sugar powder and serve"
                    },
                    author="MockDataStore",
                    difficulty=1,
                    prepTime=5,
                    cookTime=5,

                    servings=8,
                    readyInTime=20,
                   // picture=UIKit.UIImage.FromBundle ("pancake")},
                   // FoodImage = base641,

                
                },

            new Item
            {
                    id = Guid.NewGuid().ToString(),
                    name = "Ricotta strawberry French toast",
                  //  description = "30 min  2 Servings   *Easy",
                    description = "Give your French toast a summer makeover with fresh berries, lashings of ricotta, honey and mint ",
                   /*
                    ingredients = new string[] {"1 Large Egg, beaten",
                    "300ml milk",
                    "1 tbsp vanilla extract",
                    "4 slices thick-cut white bread",
                    "2 tbsp butter",
                    "60g ricotta",
                    "2 tbsp honey",
                    "100g strawberries, some sliced, some halved",
                    "2 mint sprigs, leaves picked",

                },*/
                
                    author="MockDataStore",
                    steps =new List<string>{ "In a wide dish, whisk the egg, milk and vanilla together. Coat one side of the bread slices in the liquid, then carefully flip them over and leave them to soak for 1-2 mins.",
                    "Melt 1 tbsp of the butter in a large non-stick pan over a medium heat and add two slices of bread. Cook for 5 mins or until golden, then turn to cook the other side for another 5 mins. Transfer to a plate and cook the other two slices in the rest of the butter.",
                        "Mix well and add sugar to taste . Mix everything together in the food processor",
                    "Halve the toast on the diagonal and spread each slice with the ricotta. Drizzle over the honey and a pinch of flaky sea salt, and arrange some sliced strawberries in a fan across the toast. Decorate the plate with the halved strawberries and mint.",

                    },
                    difficulty =1,
                    prepTime = 10,
                    cookTime = 20,

                    servings = 2,
                    readyInTime = 30,

         //   FoodImage = base642,
            },
                /*
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
                    steps = new string[]{ "Cook the bulgur wheat following pack instructions. Heat the olive oil in a frying pan over a medium heat. Add the salmon fillets and cook for 3 mins on each side. Stir in the spring onions and cook for 1 min. Add lemon juice, honey, orange juice and zest to the pan and bubble for 1 min more to make a sauce.",
                        "Meanwhile, boil the green beans for 4 mins or until tender. Drain. Stir the bulgur wheat with a fork, mixing in the green beans, lemon zest and a little of the sauce. Serve the salmon on a bed of bulgur and beans, with the rest of the sauce spooned over.",


                    },
                    Author="MockDataStore",
                Difficulty = "Easy",
                PrepTime = 5,
                CookTime = 20,

                ServingSize = 4,
                ReadyTime = 25,
                picture = UIKit.UIImage.FromBundle("salmon")
            },

                new Item { Id = Guid.NewGuid().ToString(),
                    Text = "Huey's Italian sausage dog",
                    Description="20 min  8 Servings   *Easy",
                    BriefDescribtion="Very sweet and easy to prepare pancakes",
                    Ingrediants=new string[]{

                         "  6 well-flavoured thick sausages",
                        "1 (200 g) jar chargrilled red capsicums",
                        "4 garlic cloves, crushed",
                        "1⁄2red onion, cut into wedges",
                        "6 pitted black olives, finely sliced, kalamata are the tastiest",
                        "1 cup italian tomato, cooking sauce",
                        "salt, to taste",
                        "fresh ground pepper, to taste",
                        "10 leaves fresh basil",
                        "olive oil",
                        "2 French baguettes",
                        "grated mozzarella cheese or tasty cheese",
                        "grated parmesan cheese",
                    },
                    steps=new string[]{

                       " Preheat the grill.",
"Blanch the sausages in simmering water until just firm to the touch; drain well.",
"Heat 1 tablespoon of oil from the capsicums in a large pan and gently sauté the garlic and onion until they have softened but not browned.",
"Add the olives, the capsicums, the tomato cooking sauce and the seasonings. Mix well and cook until thickish. Then stir in 8 torn basil leaves.",
"While the sauce is cooking, pan fry the sausages in a thin layer of oil in another pan until they are golden brown.",
"Then cut the two baguettes into three pieces about the length of the sausages; make cuts in the centre(but NOT right through) and insert a sausage topped with the sauce inside each piece of the baguette.",
"Place on the sausage-filled baguettes on a baking tray, top with cheeses and grill until golden and bubbling.",
"Serve with a garnish of basil.",
                    },
                    Author="MockDataStore",
                    Difficulty="Easy",
                    PrepTime=5,
                    CookTime=25,

                    ServingSize=6,
                    ReadyTime=30,
                    picture=UIKit.UIImage.FromBundle ("img1")},


                new Item
            {
                Id = Guid.NewGuid().ToString(),
                    Text = "Smothered flad iron stake in a paresan pepper sauce",
                Description = "30 min  2 Servings   *Easy",
                    BriefDescribtion = "Fresh citrus flavours turn a salmon fillet into a special meal",
                    Ingrediants = new string[] {"1 lb flat iron steak",
                        "1/2 cup zesty Italian dressing, divided",
                        "1/3 cup sour cream",
                        "4 1/2 teaspoons parmesan cheese, grated",
                        "3/4 teaspoon course black pepper",
                        "1/4 teaspoon sea salt",
                        "2 garlic cloves, chopped",
                        "1 large onion, thinly sliced",


                },
                    steps = new string[]{ "Pour 1/4 cup dressing over steak and seal in a Ziploc bag. Refrigerate at least 30 minutes or overnight to marinate.",
                        "Combine sour cream, 2 tbsp of the remaining dressing, Parmesan cheese, salt and pepper. Refrigerate until serving time.",
                        "Heat remaining 2 tbsp dressing and garlic in large nonstick skillet on medium heat. Add onions; cook until golden brown, stirring frequently. Remove onions; set aside.",
                        "Drain steak; discard marinade. Cook steak in same skillet on medium heat 3-4 on each side for medium doneness. Place on cutting board; slice crosswise into thin strips. Serve steak topped with sauce and onions.",

                    },
                    Author="MockDataStore",
                Difficulty = "Easy",
                PrepTime = 10,
                CookTime = 15,

                ServingSize = 2,
                ReadyTime = 25,
                picture = UIKit.UIImage.FromBundle("img2")
            },

                new Item
            {
                Id = Guid.NewGuid().ToString(),
                    Text = " General Tso's chicken",
                Description = "50 min  8 Servings   *Intermediate",
                    BriefDescribtion = "Fresh citrus flavours turn a salmon fillet into a special meal",
                    Ingrediants = new string[] {"3 lbs boneless skinless chicken breasts, cut into chunks",
                        "2 cups green onions, sliced",
                        "8 small dried chilies, seeds removed (bird pepper or thai chilies are good)",
                        "1⁄4 cup soy sauce, low sodium preferred",
                        "1 egg, beaten",
                        "1 cup cornstarch",
                        "1⁄2 cup cornstarch",
                        "1⁄4 cup water",
"1 1⁄2 teaspoons fresh garlic, minced",
"3⁄4 cup sugar",
                        "1⁄2 cup soy sauce",
"1⁄4 cup white vinegar",
"1⁄4 cup sherry wine or 1⁄4 cup white wine",
"14 1⁄2 ounces chicken broth (a can)",

                },
                    steps = new string[]{ "Place sauce ingredients in a quart jar with a lid and shake to mix. If you make this ahead of time just refrigerate until needed, shaking it again when you are ready to use it. This also keeps your dirty dishes down.",
                        "Mix cornstarch slurry in a large bowl- the mixture will be strange but trust me it works. It will be VERY thick almost paste like. Add ALL the chicken pieces and stir to coat. Using a fork remove ONE chicken piece at a time and let the excess mixture drip off. YES even though the mixture has a weird consistency it will not stick like paste and the excess will drip off. Add chicken to the hot (350 degree) oil and fry until crispy. Only cook 7 or 8 chicken pieces at a time. You do not want to lower the temp of the oil by cooking too many at a time. You can use a simple cooking or candy thermometer to judge the temp of the oil.",
                        "Drain on paper towels. Want them extra crispy? Put them on a rack over a sheet pan. Keep warm- I just put them in the oven with the oven off. Repeating until all chicken is fried.",
                        "In a separate wok or large skillet add a small amount of oil and heat to 400 degrees. Again, a candy thermometer works great. (Want less dishes? You can just drain the oil after you fry all the chicken, leave a small amount (about a tsp) in the pan and use the same pan if you like.)",
                        "Add green onions and hot peppers and stir fry about 30 seconds.",
                        "Stir (or shake jar) sauce mixture, and then add to pan with onions and peppers, cook until thick. Thick like the same sauce you get at a restaurant.you want it to just coat the chicken. If it gets too thick, add a little water or other liquid. The thickness of the sauce should be similar to what you get when ordering this at a restaurant.",
                        "Add chicken to sauce in wok and heat just until the chicken is hot enough for you. It may not even need a minute if you kept the chicken warm. The quicker you serve it the crispier the chicken stays.",

                    },
                    Author="MockDataStore",
                Difficulty = "Intermediate",
                PrepTime = 10,
                CookTime = 40,

                ServingSize = 8,
                ReadyTime = 50,
                picture = UIKit.UIImage.FromBundle("img3")
            },
            */
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
            var _item = items.Where((Item arg) => arg.id == item.id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Item arg) => arg.id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
