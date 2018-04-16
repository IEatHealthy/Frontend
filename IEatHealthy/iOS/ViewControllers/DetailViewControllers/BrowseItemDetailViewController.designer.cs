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
    [Register ("ItemDetailViewController")]
    partial class BrowseItemDetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView Brieflabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DifficultyLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView IngredianPic { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ItemNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView listIngrediants { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ReadyInLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ServingSizeLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Brieflabel != null) {
                Brieflabel.Dispose ();
                Brieflabel = null;
            }

            if (DifficultyLabel != null) {
                DifficultyLabel.Dispose ();
                DifficultyLabel = null;
            }

            if (IngredianPic != null) {
                IngredianPic.Dispose ();
                IngredianPic = null;
            }

            if (ItemNameLabel != null) {
                ItemNameLabel.Dispose ();
                ItemNameLabel = null;
            }

            if (listIngrediants != null) {
                listIngrediants.Dispose ();
                listIngrediants = null;
            }

            if (ReadyInLabel != null) {
                ReadyInLabel.Dispose ();
                ReadyInLabel = null;
            }

            if (ServingSizeLabel != null) {
                ServingSizeLabel.Dispose ();
                ServingSizeLabel = null;
            }
        }
    }
}