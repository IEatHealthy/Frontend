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
    [Register ("ItemNewViewController")]
    partial class ItemNewViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSaveItem { get; set; }

        [Action ("BtnSaveItem_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSaveItem_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnSaveItem != null) {
                btnSaveItem.Dispose ();
                btnSaveItem = null;
            }
        }
    }
}