using Foundation;
using System;
using System.IO;
using System.Net;
using UIKit;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace IEatHealthy.iOS
{
    public class user
    {
        public string email { get; set; }
        public string firstName { get; set; }
        public string lasrName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int skillLevel { get; set; }
        public bool signedup = false;


    };

    public partial class SignupController : UIViewController
    {
        public static AppDelegate App
        {
            get { return (AppDelegate)UIApplication.SharedApplication.Delegate; }
        }

        public int skill = 1;
        public bool created = true;
        public bool nodata = false;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            signupbutton.Layer.CornerRadius = 7;
            btn1.Layer.CornerRadius = 8;
            btn3.Layer.CornerRadius = 8;
            btn2.Layer.CornerRadius = 8;

        }
        public SignupController(IntPtr handle) : base(handle)
        {
        }

        partial void Signupbutton_TouchUpInside(UIButton sender)
        {
            
        }

        partial void Btn1_TouchUpInside(UIButton sender)
        {
            btn1.BackgroundColor = UIColor.FromRGB(144, 197, 244);
            btn2.BackgroundColor = UIColor.White;
            btn3.BackgroundColor = UIColor.White;
            skill = 1;
        }

        partial void Btn2_TouchUpInside(UIButton sender)
        {
            btn2.BackgroundColor = UIColor.FromRGB(144, 197, 244);
            btn1.BackgroundColor = UIColor.White;
            btn3.BackgroundColor = UIColor.White;
            skill = 2;
        }

        partial void Btn3_TouchUpInside(UIButton sender)
        {
            btn3.BackgroundColor = UIColor.FromRGB(144, 197, 244);
            btn2.BackgroundColor = UIColor.White;
            btn1.BackgroundColor = UIColor.White;
            skill = 3;
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "signupsegue")
            {
                created = true;
                signup();
                if (created == true)
                {
                    getdata(App.currentAccount.JWTToken);

                    if (created == true && nodata == false)
                    {
                        base.PrepareForSegue(segue, sender);
                    }
                }
            }
          
        }
        
		public async Task signup()
        {
            var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info/api/user/{0}", UEmail.Text));
           
            request.ContentType = "application/json";
            request.Method = "POST";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new user
                {
                    username = Uname.Text,
                    email = UEmail.Text,
                    password = UPword.Text,
                    firstName = Fname.Text,
                    lasrName = Lname.Text,
                    skillLevel = skill,

                });

                streamWriter.Write(json);
            }


            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    App.currentAccount.JWTToken = result;

                }
            }
            catch{
                created = false;
            }
            

        
        }
        public async void getdata(string myResponse)
        {
            var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info//api/user/accountOwner/{0}?token={1}", UEmail.Text,myResponse));
            request.ContentType = "application/JSON";
            request.Method = "GET";
            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                string aResponse = "";
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {

                    aResponse = sr.ReadToEnd();
                   
                    App.currentAccount = JsonConvert.DeserializeObject<UserAccount>(aResponse);
                    App.currentAccount.JWTToken = myResponse;
                    nodata = false;
                

                }
            }
            catch (System.Net.WebException err)
            {
                nodata = true;
                Uname.Text = err.ToString();
            }
        }




    }
}


