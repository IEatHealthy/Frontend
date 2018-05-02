using Foundation;
using System;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using System.Net;
using System.IO;
using Newtonsoft.Json;
namespace IEatHealthy.iOS
{
    public partial class RecipesViewController : UIViewController
    {
        public RecipesViewController(IntPtr handle) : base(handle)
        {
        }
        public static AppDelegate App
        {
            get { return (AppDelegate)UIApplication.SharedApplication.Delegate; }
        }
        public override void ViewDidLoad()
        {
            scrollview.BackgroundColor = UIColor.White;
            base.ViewDidLoad();
            List<Item> items = new List<Item>();

            foreach (string item in App.currentAccount.bookmarkedRecipes)
            {
                var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info/api/recipe/id?id={0}&token={1}", item, App.currentAccount.JWTToken));
                request.ContentType = "application/JSON";
                request.Method = "GET";


                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                string aResponse = "";
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {

                    aResponse = sr.ReadToEnd();
                    //storing token in CurrentAccount instance of type UserAccount

                    // App.currentAccount.JWTToken = aResponse;

                    //   App.currentAccount.JWTToken = aResponse;

                    //  objectret = aResponse;
                    // Item newitem= JsonConvert.DeserializeObject<Item>(json);
                    Item newitem = JsonConvert.DeserializeObject<Item>(aResponse);

                }

            }
            int y = 40;
            foreach (Item recipe in items)
            {
                UIImageView recipepic = new UIImageView(new CGRect(30, y, 20, 20));
                var imageBytes = Convert.FromBase64String(recipe.foodImage.data);
                var imagedata = NSData.FromArray(imageBytes);
                var uiimage = UIImage.LoadFromData(imagedata);
                recipepic.Image = uiimage;
                scrollview.AddSubview(recipepic);
                y += 60;

            }


        }
    }
}