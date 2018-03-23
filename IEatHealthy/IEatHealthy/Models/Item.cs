using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
namespace IEatHealthy
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string[] Ingrediants { get; set; }
        public string Description { get; set; }
        public int PrepTime { get; set; }
        public int CookTime { get; set; }
        public UIImage picture { get; set;}
        public int calorieCount { get; set; }
        public int IngrediantsRating { get; set; }

    }
}
