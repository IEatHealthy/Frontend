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
            btn1.Layer.CornerRadius = 8;
            btn3.Layer.CornerRadius = 8;
            btn2.Layer.CornerRadius = 8;
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

partial void Btn1_TouchUpInside(UIButton sender)
        {
            btn1.BackgroundColor = UIColor.FromRGB(144, 197, 244);
            btn2.BackgroundColor = UIColor.White;
            btn3.BackgroundColor = UIColor.White;
        }

partial void Btn2_TouchUpInside(UIButton sender)
        {
            btn2.BackgroundColor = UIColor.FromRGB(144, 197, 244);
            btn1.BackgroundColor = UIColor.White;
            btn3.BackgroundColor = UIColor.White;
        }

partial void Btn3_TouchUpInside(UIButton sender)
        {
            btn3.BackgroundColor = UIColor.FromRGB(144, 197, 244);
            btn2.BackgroundColor = UIColor.White;
            btn1.BackgroundColor = UIColor.White;
            }
    }
}


