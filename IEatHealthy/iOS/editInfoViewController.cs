using Foundation;
using System;
using UIKit;

namespace IEatHealthy.iOS
{
    public partial class editInfoViewController : UIViewController
    {
        public editInfoViewController (IntPtr handle) : base (handle)
        {

        }

            public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            verifyNewPassword.Frame = new CGRect(40, 250, 280, 30);
            verifyNewPassword.Text = null;
            verifyNewPassword.Placeholder = "New Password";
            newPassword.Frame = new CGRect(40, 300, 280, 30);
            newPassword.Text = null;
            newPassword.Placeholder = "Verify New Password";

            saveChanges.Frame = new CGRect(40, 370, 280, 35);
            saveChanges.Font = UIFont.FromName("Helvetica-Bold", 15f);
            saveChanges.BackgroundColor = UIColor.FromRGB(37, 153, 254);
            saveChanges.SetTitleColor(UIColor.White, UIControlState.Normal);
            saveChanges.Layer.CornerRadius = 5;
            saveChanges.SetTitle("Save Changes", UIControlState.Normal);

        } 

    }
}