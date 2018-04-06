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
        public bool sign = true;
        partial void LoginButton_TouchUpInside(UIButton sender)
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
                    // web token received as string under myResponse
                    myResponse = sr.ReadToEnd();

                }
            }
            catch (System.Net.WebException)
            {

                errMsg.Text = "Username or password is incorrect";
                sign = false;
            }


        }


		public log(IntPtr handle) : base(handle)
        {


        }

    }
}
