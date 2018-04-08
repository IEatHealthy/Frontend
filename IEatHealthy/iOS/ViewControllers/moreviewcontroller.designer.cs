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
    [Register ("moreviewcontroller")]
    partial class moreviewcontroller
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView profileimgButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField ProfiletextLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton signOutButton { get; set; }

        [Action ("SignOutButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SignOutButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("UIButton118449_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton118449_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (profileimgButton != null) {
                profileimgButton.Dispose ();
                profileimgButton = null;
            }

            if (ProfiletextLabel != null) {
                ProfiletextLabel.Dispose ();
                ProfiletextLabel = null;
            }

            if (signOutButton != null) {
                signOutButton.Dispose ();
                signOutButton = null;
            }
        }
    }
}