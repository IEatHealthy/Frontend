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
    [Register ("SelectIngredient")]
    partial class SelectIngredient
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem Add { get; set; }

        [Action ("Add_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Add_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (Add != null) {
                Add.Dispose ();
                Add = null;
            }
        }
    }
}