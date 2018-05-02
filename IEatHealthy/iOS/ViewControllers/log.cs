using Foundation;
using System;
using UIKit;
using CoreGraphics;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IEatHealthy.iOS
{
    
    public partial class log : UIViewController
    {
        UITextView errMsg = new UITextView(new System.Drawing.RectangleF(46, 160, 270, 26));
        public bool datareceved = false;
        public bool loggedin = false;
        public string userdata="";
        public string tokendata = "";
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //bottomLabel.Font = UIFont.FromName("Helvetica-Bold", 10f);

            LoginButton.Layer.CornerRadius = 7;

            errMsg.TextAlignment = UITextAlignment.Center;
            errMsg.Layer.CornerRadius = 5;
            View.AddSubview(errMsg);
            loginEmail.Text = "test@ieathealthy.info";
            loginPassword.Text = "potato2";
           
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
                        tokendata = myResponse;
                         getdata(myResponse);

                       // getrecipe(myResponse);
                      

                   
                       if (datareceved == true)
                        {
                          /*I var newitem = JsonConvert.DeserializeObject<Item>(objectret);
                            errMsg.Text = newitem.foodImage.data;
                            var imageBytes = Convert.FromBase64String(newitem.foodImage.data);
                            var imagedata = NSData.FromArray(imageBytes);
                            var uiimage = UIImage.LoadFromData(imagedata);


                            UIImageView aad = new UIImageView(new CGRect(200, 0, 100, 100));
                            aad.Image = uiimage;
                            View.AddSubview(aad);
                            */
                      }

                        loggedin = true;

                    }
                }
                catch (System.Net.WebException)
                {

                    errMsg.Text = "Username or password is incorrect";
                    errMsg.BackgroundColor = UIColor.FromRGB(244, 217, 66);
                    loggedin = false;
                }
                if (loggedin == true && datareceved == true)
                {
                    App.currentAccount = JsonConvert.DeserializeObject<UserAccount>(userdata);
                    App.currentAccount.JWTToken = tokendata;
                    App.currentAccount.email = loginEmail.Text;
                    return base.ShouldPerformSegue(segueIdentifier, sender);
                }
                else return false;
            }
            else return base.ShouldPerformSegue(segueIdentifier, sender);
           

        }
    

        public async void getdata(string myResponse)
        { 
            var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info//api/user/accountOwner/{0}?token={1}", loginEmail.Text,myResponse));
            request.ContentType = "application/JSON";
            request.Method = "GET";
            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                string aResponse = "";
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {

                    aResponse = sr.ReadToEnd();

                    userdata = aResponse;
                    datareceved = true;

                    //storing token in CurrentAccount instance of type UserAccount
                    // App.currentAccount.JWTToken = aResponse;
                    // objectret = aResponse;
                    // UserAccount aa = JsonConvert.DeserializeObject<UserAccount>(aResponse);
                    // string bba = JsonConvert.SerializeObject(aa);
                    UITextView aaaa = new UITextView(new CGRect(50, 300, 250, 400));
                    aaaa.Text = aResponse.Replace(",", "," + System.Environment.NewLine);
                    View.AddSubview(aaaa);
                    datareceved = true;

                }
            }
            catch (System.Net.WebException)
            {

                errMsg.Text = "couldnt retreve user data";
                errMsg.BackgroundColor = UIColor.FromRGB(244, 217, 66);
                datareceved = false;
            }
        }

        public async void getrecipe(string myResponse)
        {
            var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info/api/recipe/name?name=Grilled%20Salmon&token={0}", myResponse));
            request.ContentType = "application/JSON";
            request.Method = "GET";

            try
            {
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
                 //   newitem=JsonConvert.DeserializeObject<>
                //   UITextView bbb = new UITextView(new CGRect(150, 500, 200, 400));
                //   bbb.Text = aResponse.Replace(",", "," + System.Environment.NewLine);
                //  View.AddSubview(bbb);
                    datareceved = true;
                  
                }

            }
            catch{
                UITextView ccc = new UITextView(new CGRect(150, 500, 200, 400));
                ccc.Text = "recipe not found";
                View.AddSubview(ccc);

            }
           
        }


        public log(IntPtr handle) : base(handle)
        {
        }

    }
}
