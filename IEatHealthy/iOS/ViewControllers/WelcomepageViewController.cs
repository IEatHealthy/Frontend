using Foundation;
using System;
using UIKit;

namespace IEatHealthy.iOS
{
    public partial class WelcomepageViewController : UIViewController
    {
        public WelcomepageViewController (IntPtr handle) : base (handle)
        {
        }
		public override void ViewDidLoad()
		{
            base.ViewDidLoad();
            bottomLabel.Font = UIFont.FromName("Helvetica-Bold", 10f);
		}

        partial void UIButton62896_TouchUpInside(UIButton sender)
        {
            UIApplication.SharedApplication.OpenUrl(new NSUrl("https://en-gb.facebook.com/login/"));
        }
    }
}