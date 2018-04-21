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
        UIKit.UIButton btn1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btn2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btn3 { get; set; }

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

        [Action ("Btn1_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Btn1_TouchUpInside (UIKit.UIButton sender);

        [Action ("Btn2_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Btn2_TouchUpInside (UIKit.UIButton sender);

        [Action ("Btn3_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Btn3_TouchUpInside (UIKit.UIButton sender);

        [Action ("Signupbutton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Signupbutton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btn1 != null) {
                btn1.Dispose ();
                btn1 = null;
            }

            if (btn2 != null) {
                btn2.Dispose ();
                btn2 = null;
            }

            if (btn3 != null) {
                btn3.Dispose ();
                btn3 = null;
            }

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