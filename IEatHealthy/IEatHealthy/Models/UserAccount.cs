using System;
using Foundation;
using Security;
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
        /*
        public string StoreKeysInKeychain(string token, string value )
        {
            SecRecord Record = new SecRecord(SecKind.GenericPassword)
            {
                Generic = NSData.FromString("foo"),
                ValueData = NSData.FromString("value")
                //Generic = NSData.FromString(token),

            };

                SecStatusCode status = SecStatusCode.Success;
                status = SecKeyChain.Add (Record);

                if (status == SecStatusCode.Success)
                {
                    return GetRecordsFromKeychain(token);
                }
                else
                throw new Exception("Cannot store in keychain:" + status) ;
        }

        public string GetRecordsFromKeychain(string token)
        {
            SecStatusCode res;
            var rec = new SecRecord(SecKind.GenericPassword)
            {
                ValueData = NSData.FromString(token)
            };
            var match = SecKeyChain.QueryAsRecord(rec, out res);

            if (match != null)
                return match.ValueData.ToString();

            return "Error";
        }
        */
        }

}
