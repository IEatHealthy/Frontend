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
        UIKit.UITextView BriefDescInput { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BtnPick { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField cooktime { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DifficultyLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel IngrediantLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel InstructionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField preptime { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField ReadyTimeIput { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField RecipeName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView scrollView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField ServingSizeInput { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel sToolLabel { get; set; }

        [Action ("BtnPick_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnPick_TouchUpInside (UIKit.UIButton sender);

        [Action ("PrepValueChange:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PrepValueChange (UIKit.UITextField sender);

        void ReleaseDesignerOutlets ()
        {
            if (BriefDescInput != null) {
                BriefDescInput.Dispose ();
                BriefDescInput = null;
            }

            if (BtnPick != null) {
                BtnPick.Dispose ();
                BtnPick = null;
            }

            if (cooktime != null) {
                cooktime.Dispose ();
                cooktime = null;
            }

            if (DifficultyLabel != null) {
                DifficultyLabel.Dispose ();
                DifficultyLabel = null;
            }

            if (imgView != null) {
                imgView.Dispose ();
                imgView = null;
            }

            if (IngrediantLabel != null) {
                IngrediantLabel.Dispose ();
                IngrediantLabel = null;
            }

            if (InstructionLabel != null) {
                InstructionLabel.Dispose ();
                InstructionLabel = null;
            }

            if (preptime != null) {
                preptime.Dispose ();
                preptime = null;
            }

            if (ReadyTimeIput != null) {
                ReadyTimeIput.Dispose ();
                ReadyTimeIput = null;
            }

            if (RecipeName != null) {
                RecipeName.Dispose ();
                RecipeName = null;
            }

            if (scrollView != null) {
                scrollView.Dispose ();
                scrollView = null;
            }

            if (ServingSizeInput != null) {
                ServingSizeInput.Dispose ();
                ServingSizeInput = null;
            }

            if (sToolLabel != null) {
                sToolLabel.Dispose ();
                sToolLabel = null;
            }
        }
    }
}