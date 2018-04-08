using Foundation;
using System;
using UIKit;
using CoreGraphics;
using System.Net;
using System.IO;

namespace IEatHealthy.iOS
{
    public partial class log : UIViewController
    {

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //bottomLabel.Font = UIFont.FromName("Helvetica-Bold", 10f);
            LoginButton.Layer.CornerRadius = 10;
        }

        public static AppDelegate App
        {
            get { return (AppDelegate)UIApplication.SharedApplication.Delegate; }
        }

        partial void LoginButton_TouchUpInside(UIButton sender)
        {
            
        }
        public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender){
          
            if (segueIdentifier == "LoginSegue")
            {
                //authenticating user login 
                var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info/api/user/{0}/{1}", loginEmail.Text, loginPassword.Text));
                request.ContentType = "application/JSON";
                request.Method = "GET";
                try
                {
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    string myResponse = "";
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        //web token received as string under myResponse
                        myResponse = sr.ReadToEnd();
                        //storing token in CurrentAccount instance of type UserAccount
                        App.currentAccount.JWTToken = myResponse;
                    }
                }
                catch (System.Net.WebException)
                {

                    errMsg.Text = "Username or password is incorrect";
                    errMsg.Layer.CornerRadius = 10;
                    errMsg.BackgroundColor = UIColor.FromRGB(244, 217, 66);
                    return false;
                }
            }
            return base.ShouldPerformSegue(segueIdentifier, sender);
        }

		public log(IntPtr handle) : base(handle)
        {


        }

    }
}
