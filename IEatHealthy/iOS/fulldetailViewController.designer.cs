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
    [Register ("FullDetailViewController")]
    partial class FullDetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView aass { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ddf { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lav { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton newButton { get; set; }

        [Action ("Ddf_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Ddf_TouchUpInside (UIKit.UIButton sender);

        [Action ("NewButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void NewButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("UIButton172966_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton172966_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (aass != null) {
                aass.Dispose ();
                aass = null;
            }

            if (ddf != null) {
                ddf.Dispose ();
                ddf = null;
            }

            if (lav != null) {
                lav.Dispose ();
                lav = null;
            }

            if (newButton != null) {
                newButton.Dispose ();
                newButton = null;
            }
        }
    }
}