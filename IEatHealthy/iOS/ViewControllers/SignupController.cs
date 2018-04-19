using Foundation;
using System;
using UIKit;

namespace IEatHealthy.iOS
{
    public partial class SignupController : UIViewController
    {
		public override void ViewDidLoad()
		{
            base.ViewDidLoad();
            signupbutton.Layer.CornerRadius = 7;
		}
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


