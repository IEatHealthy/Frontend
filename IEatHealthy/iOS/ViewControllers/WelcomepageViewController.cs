using Foundation;
using System;
using UIKit;

namespace IEatHealthy.iOS
{
    public partial class WelcomepageViewController : UIViewController
    {
    partial void LoginMainButton_TouchUpInside(UIButton sender)
        {
            
        }

        public WelcomepageViewController (IntPtr handle) : base (handle)
        {
        }
		public override void ViewDidLoad()
		{
            base.ViewDidLoad();
            //bottomLabel.Font = UIFont.FromName("Helvetica-Bold", 10f);
            LoginMainButton.Layer.CornerRadius = 7; 
                    
		}


    }
}