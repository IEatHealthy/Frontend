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
        partial void LoginButton_TouchUpInside(UIButton sender)
        {
           // attempting to authenticate user login 
            var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info/api/user/{0}/{1}",loginEmail.Text, loginPassword.Text));
            request.ContentType = "application/JSON";
            request.Method = "GET"; 

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse){
                if (response.StatusCode != HttpStatusCode.OK)
                    Console.WriteLine("status code not ok");
                using (StreamReader reader = new StreamReader(response.GetResponseStream())){
                    var content = reader.ReadToEnd();
                    if (string.IsNullOrWhiteSpace(content))
                        Console.WriteLine("respone string invalid");
                    else
                        Console.WriteLine("Response: " + content);
                }
            } 

            //var aleart = UIAlertController.Create("Alert", "Username or password is incorrect", UIAlertControllerStyle.Alert);
            //aleart.AddAction(UIAlertAction.Create("ok", UIAlertActionStyle.Cancel, null));

        }
           
        public log (IntPtr handle) : base (handle)
        {
            
            
        }

    }
}