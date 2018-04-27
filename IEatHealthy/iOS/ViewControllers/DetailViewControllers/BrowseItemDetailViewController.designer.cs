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
        UIKit.UIButton CommentButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ReviewButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView scrollView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CommentButton != null) {
                CommentButton.Dispose ();
                CommentButton = null;
            }

            if (ReviewButton != null) {
                ReviewButton.Dispose ();
                ReviewButton = null;
            }

            if (scrollView != null) {
                scrollView.Dispose ();
                scrollView = null;
            }
        }
    }
}