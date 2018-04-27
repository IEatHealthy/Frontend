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
    [Register ("ItemsViewController")]
    partial class BrowseViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnAddItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationItem MainNavigation { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView RecipeTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnAddItem != null) {
                btnAddItem.Dispose ();
                btnAddItem = null;
            }

            if (MainNavigation != null) {
                MainNavigation.Dispose ();
                MainNavigation = null;
            }

            if (RecipeTableView != null) {
                RecipeTableView.Dispose ();
                RecipeTableView = null;
            }
        }
    }
}