using Foundation;
using System;
using UIKit;

namespace IEatHealthy.iOS
{
    public partial class SignupController : UIViewController
    {
        public SignupController(IntPtr handle) : base(handle)
        {
        }

        partial void Signupbutton_TouchUpInside(UIButton sender)
        {
            var user001 = new UserAccount
            {
                UserName = Uname.Text,
            };
        }
    }
}


