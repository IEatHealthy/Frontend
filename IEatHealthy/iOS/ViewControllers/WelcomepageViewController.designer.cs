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
    [Register ("WelcomepageViewController")]
    partial class WelcomepageViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel bottomLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (bottomLabel != null) {
                bottomLabel.Dispose ();
                bottomLabel = null;
            }
        }
    }
}