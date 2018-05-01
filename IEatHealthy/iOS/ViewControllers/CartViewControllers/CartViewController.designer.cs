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
    [Register ("CartViewController")]
    partial class CartViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem ClearBtn { get; set; }

        [Action ("ClearBtn_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ClearBtn_Activated (UIKit.UIBarButtonItem sender);

        [Action ("UIBarButtonItem245388_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIBarButtonItem245388_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (ClearBtn != null) {
                ClearBtn.Dispose ();
                ClearBtn = null;
            }
        }
    }
}