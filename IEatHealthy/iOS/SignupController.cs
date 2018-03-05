using Foundation;
using System;
using UIKit;

namespace IEatHealthy.iOS
{
    public partial class SignupController : UIViewController
    {
        public SignupController (IntPtr handle) : base (handle)
        {
        }
        public string Username { get; set; } 
        public string Userpassword { get; set; } 
        public string  UserFirstName{ get; set; }
        public string  UserLastName{ get; set; } 
        public string  UserEmail{ get; set; } 
        public string  UserCookingSkill{ get; set; } 


         
        //intialise  
      

        partial void Signupbutton_TouchUpInside(UIButton sender)
        {
            this.Username = Uname.Text;
            this.Userpassword = UPword.Text;
        }
    }
}