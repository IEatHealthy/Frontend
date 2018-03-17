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
    [Register ("SignupController")]
    partial class SignupController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField Fname { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField Lname { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton signupbutton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider UCskill { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField UEmail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField Uname { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField UPword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField URPword { get; set; }

        [Action ("Signupbutton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Signupbutton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (Fname != null) {
                Fname.Dispose ();
                Fname = null;
            }

            if (Lname != null) {
                Lname.Dispose ();
                Lname = null;
            }

            if (signupbutton != null) {
                signupbutton.Dispose ();
                signupbutton = null;
            }

            if (UCskill != null) {
                UCskill.Dispose ();
                UCskill = null;
            }

            if (UEmail != null) {
                UEmail.Dispose ();
                UEmail = null;
            }

            if (Uname != null) {
                Uname.Dispose ();
                Uname = null;
            }

            if (UPword != null) {
                UPword.Dispose ();
                UPword = null;
            }

            if (URPword != null) {
                URPword.Dispose ();
                URPword = null;
            }
        }
    }
}