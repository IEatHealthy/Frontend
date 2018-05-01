using Foundation;
using System;
using UIKit;
using CoreGraphics;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace IEatHealthy.iOS
{
    public partial class editProfileViewController : UIViewController
    {
        public class Password{
            public string password { get; set; }
        }

        public editProfileViewController (IntPtr handle) : base (handle)
        {
        }
        public static AppDelegate App
        {
            get { return (AppDelegate)UIApplication.SharedApplication.Delegate; }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            verifyNewPassword.Frame = new CGRect(40, 250, 280, 30);
            verifyNewPassword.Text = null;
            verifyNewPassword.Placeholder = "New Password";
            newPassword.Frame = new CGRect(40, 300, 280, 30);
            newPassword.Text = null;
            newPassword.Placeholder = "Verify New Password";

            saveChanges.Frame = new CGRect(40, 370, 280, 35);
            saveChanges.Font = UIFont.FromName("Helvetica-Bold", 15f);
            saveChanges.BackgroundColor = UIColor.FromRGB(37, 153, 254);
            saveChanges.SetTitleColor(UIColor.White, UIControlState.Normal);
            saveChanges.Layer.CornerRadius = 5;
            saveChanges.SetTitle("Save Changes", UIControlState.Normal);

            backToProfile.Frame = new CGRect(40, 430, 280, 35);
            backToProfile.Font = UIFont.FromName("Helvetica-Bold", 15f);
            backToProfile.BackgroundColor = UIColor.Red;
            backToProfile.SetTitleColor(UIColor.White, UIControlState.Normal);
            backToProfile.Layer.CornerRadius = 5;
            backToProfile.SetTitle("Back To Profile Page", UIControlState.Normal);

        }
		public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
		{
            if (segueIdentifier == "ChangePass")
            {
                if (verifyNewPassword.Text == newPassword.Text)
                {
                    
                    var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info/api/user/{0}?token={1}", App.currentAccount.email, App.currentAccount.JWTToken));
                    request.ContentType = "application/JSON";
                    request.Method = "PUT";

                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        string json = JsonConvert.SerializeObject(new Password
                        {
                            password = newPassword.Text
                        });

                        streamWriter.Write(json);
                    }
                   try
                    {
                        var httpResponse = (HttpWebResponse)request.GetResponse();
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            var result = streamReader.ReadToEnd();
                            return base.ShouldPerformSegue(segueIdentifier, sender);
                        }
                    }
                   catch (System.Net.WebException)
                    {
                        var okAlertController = UIAlertController.Create("Error", "Password Not Changed", UIAlertControllerStyle.Alert);
                        okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                        PresentViewController(okAlertController, true, null);
                    }


                }
                else
                {
                    var okAlertController = UIAlertController.Create("Error", "Passwords Do Not Match", UIAlertControllerStyle.Alert);
                    okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                    PresentViewController(okAlertController, true, null);
                }

            }
            return base.ShouldPerformSegue(segueIdentifier, sender);
		}
	}
}