using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
namespace IEatHealthy
{
    public class UserRating
    {
        public string userEmail { get; set; }
        public int userRating { get; set; }
    }

    public class UserReview
    {
        public string userEmail { get; set; }
        public string userReview { get; set; }
    }
    public class IngredientItem
    { 
        public string unitOfMeasure { get; set; }
        public float amount { get; set; }
        public string desc { get; set; }
    }
    public class FoodImage{
        public int type { get; set; }
        public NSString data { get; set; }
    }
    public class RecipeRating{
        public string id;
        public List<UserRating> ratings;
        public double totalRating;
    }
    public class Item
    {
        public string id { get; set; }
        public string stringId { get; set; }
        public string name { get; set; }
        public int typeOfFood { get; set; }
        public float servings { get; set; }
        public string description { get; set; }
        public float prepTime { get; set; }
        public float cookTime { get; set; }
        public float readyInTime { get; set; }
        public FoodImage foodImage { get; set; }
        public List<IngredientItem> ingredients { get; set; }
        public List<string> steps { get; set; }
        public List<string> toolsNeeded { get; set; }
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
