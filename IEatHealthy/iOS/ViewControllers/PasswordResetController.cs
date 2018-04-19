using Foundation;
using System;
using UIKit;

namespace IEatHealthy.iOS
{
    public partial class PasswordResetController : UIViewController
    {
		public override void ViewDidLoad()
		{
            base.ViewDidLoad();
            BackButton.Layer.CornerRadius = 7;
            ResetButton.Layer.CornerRadius = 7;
		}
		partial void UIButton47525_TouchUpInside(UIButton sender)
        {
            PasswordResetMsg.Text = "The email entered is not recognized";
        }

        public PasswordResetController (IntPtr handle) : base (handle)
        {
        }
    }
}