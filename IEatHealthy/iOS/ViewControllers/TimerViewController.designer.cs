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
    [Register ("TimerViewController")]
    partial class TimerViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField HourInputLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel HourLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField MinuteInputLabl { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MinuteLable { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SecondLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton StartTimerButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton StopTimerLabel { get; set; }

        [Action ("StartTimerButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void StartTimerButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("StopTimerLabel_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void StopTimerLabel_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (HourInputLabel != null) {
                HourInputLabel.Dispose ();
                HourInputLabel = null;
            }

            if (HourLabel != null) {
                HourLabel.Dispose ();
                HourLabel = null;
            }

            if (MinuteInputLabl != null) {
                MinuteInputLabl.Dispose ();
                MinuteInputLabl = null;
            }

            if (MinuteLable != null) {
                MinuteLable.Dispose ();
                MinuteLable = null;
            }

            if (SecondLabel != null) {
                SecondLabel.Dispose ();
                SecondLabel = null;
            }

            if (StartTimerButton != null) {
                StartTimerButton.Dispose ();
                StartTimerButton = null;
            }

            if (StopTimerLabel != null) {
                StopTimerLabel.Dispose ();
                StopTimerLabel = null;
            }
        }
    }
}