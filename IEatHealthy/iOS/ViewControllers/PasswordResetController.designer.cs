// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace IEatHealthy.iOS
{
    [Register ("PasswordResetController")]
    partial class PasswordResetController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ForgotPasseord { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel PasswordResetMsg { get; set; }

        [Action ("UIButton47525_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton47525_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (ForgotPasseord != null) {
                ForgotPasseord.Dispose ();
                ForgotPasseord = null;
            }

            if (PasswordResetMsg != null) {
                PasswordResetMsg.Dispose ();
                PasswordResetMsg = null;
            }
        }
    }
}