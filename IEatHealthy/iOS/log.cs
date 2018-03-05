using Foundation;
using System;
using UIKit;
using CoreGraphics;

namespace IEatHealthy.iOS
{
    public partial class log : UIViewController
    {
        partial void LoginButton_TouchUpInside(UIButton sender)
        {
            var aleart = UIAlertController.Create("Alert", "Username or password is incorrect", UIAlertControllerStyle.Alert);
            aleart.AddAction(UIAlertAction.Create("ok", UIAlertActionStyle.Cancel, null));
            if (loginEmail.Text != "meaw " && loginPassword.Text != "meaw")
            {
                PresentViewController(aleart, true, null);
            }
        }

      



        public log (IntPtr handle) : base (handle)
        {
            
            
        }

    }
}