using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
namespace IEatHealthy
{
    public class IngredientItem{

        public string ingredientId { get; set; }
        public string unitOfMeasure { get; set; }
        public float amount { get; set; }
        public string desc { get; set; }
    }
    public class Item
    {
        public string Id { get; set; }
        public string name { get; set; }
        public int typeOfFood { get; set; }
        public int servings { get; set; }
        public string Description { get; set; }
        public int preptime { get; set; }
        public int cookTime { get; set; }
        public int readyTime { get; set; }
        public UIImage picture { get; set; }
        public List<IngredientItem> ingredients { get; set; }
        public List<string> steps { get; set; }
        public List<string> toolsNeeded { get; set; }
        public string description { set; get; }
        public string author { get; set; }
        public int difficulty { get; set; }
        public double calories { get; set; }
        public double protein { get; set; }
        public double fat { get; set; }
        public double carbohydrate { get; set; }
        public double fiber { get; set; }
        public double sugar { get; set; }
        public double calcium { get; set; }
        public double iron { get; set; }
        public double potassium { get; set; }
        public double sodium { get; set; }
        public double vitaminC { get; set; }
        public double vitAiu { get; set; }
        public double vitDiu { get; set; }
        public double cholestrol { get; set; }
       
    }
}
