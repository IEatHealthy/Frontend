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
        UIKit.UIButton BtnPick { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSaveItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField cooktime { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField preptime { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtDesc { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtTitle { get; set; }

        [Action ("BtnPick_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnPick_TouchUpInside (UIKit.UIButton sender);

        [Action ("PrepValueChange:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PrepValueChange (UIKit.UITextField sender);

        void ReleaseDesignerOutlets ()
        {
            if (BtnPick != null) {
                BtnPick.Dispose ();
                BtnPick = null;
            }

            if (btnSaveItem != null) {
                btnSaveItem.Dispose ();
                btnSaveItem = null;
            }

            if (cooktime != null) {
                cooktime.Dispose ();
                cooktime = null;
            }

            if (imgView != null) {
                imgView.Dispose ();
                imgView = null;
            }

            if (preptime != null) {
                preptime.Dispose ();
                preptime = null;
            }

            if (txtDesc != null) {
                txtDesc.Dispose ();
                txtDesc = null;
            }

            if (txtTitle != null) {
                txtTitle.Dispose ();
                txtTitle = null;
            }
        }
    }
}