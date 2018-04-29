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
    [Register ("editProfileViewController")]
    partial class editProfileViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton backToProfile { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField newPassword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton saveChanges { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField verifyNewPassword { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (backToProfile != null) {
                backToProfile.Dispose ();
                backToProfile = null;
            }

            if (newPassword != null) {
                newPassword.Dispose ();
                newPassword = null;
            }

            if (saveChanges != null) {
                saveChanges.Dispose ();
                saveChanges = null;
            }

            if (verifyNewPassword != null) {
                verifyNewPassword.Dispose ();
                verifyNewPassword = null;
            }
        }
    }
}