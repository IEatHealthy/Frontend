using System;
namespace IEatHealthy
{
    public class UserAccount
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string JWTToken { get; set; }
        public int NumberofIngrediants { get; set; }
        public int CookingSkillLevel { get; set; }
        public string[] shoppingcart { get; set; }

    }

}
