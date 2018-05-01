using System;
using System.Collections.Generic;
using System.Collections;
namespace IEatHealthy
{

    public class UserAccount
    {
        public String email { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String username { get; set; }
        public int skillLevel { get; set; }
        public ArrayList badgesEarned { get; set; }
        public ArrayList titlesEarned { get; set; }
        public Badge badgeSelected { get; set; }
        public Title titleSelected { get; set; }
        public string JWTToken { get; set; }
        public List<string> recipesCreated { get; set; }
        public List<string> bookmarkedRecipes { get; set; }
    }
    public class Badge
    {

        public int badgeId { get; set; }
        public String decsription { get; set; }
        public bool awardOnSignup { get; set; }
    }
    public class Title
    {

        public String title { get; set; }
        public String description { get; set; }
        public bool awardOnSignUp { get; set; }

    }

}
