using System;
using System.Collections;
namespace IEatHealthy
{

    public class UserAccount
    {
        private String email { get; set; }
        private String firstName { get; set; }
        private String lastName { get; set; }
        private String username { get; set; }
        private int skillLevel { get; set; }
        private ArrayList badgesEarned { get; set; }
        private ArrayList titlesEarned { get; set; }
        private Badge badgeSelected { get; set; }
        private Title titleSelected { get; set; }
        public string JWTToken { get; set; }
    }
    public class Badge
    {

        private int badgeId { get; set; }
        private String decsription { get; set; }
        private bool awardOnSignup { get; set; }
    }
    public class Title
    {

        private String title { get; set; }
        private String description { get; set; }
        private bool awardOnSignUp { get; set; }

    }

}
