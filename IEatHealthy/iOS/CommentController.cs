using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace IEatHealthy.iOS
{
    public partial class CommentController : UIViewController
    {
        public CommentController(IntPtr handle) : base(handle)
        {
        }
        public bool isCOmment = false;
        public int rating = 6;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            if (isCOmment == true)
            {
                //label1.Text = "Comment page";
                var str1 = new UIButton(UIButtonType.Custom)
                {
                    Frame = new CGRect(20, 100, 40, 40),
                };
                //CartButton.Layer.BorderWidth = 1f;
                str1.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);

                var str2 = new UIButton(UIButtonType.Custom)
                {
                    Frame = new CGRect(60, 100, 40, 40),
                };
                //CartButton.Layer.BorderWidth = 1f;
                str2.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);

                var str3 = new UIButton(UIButtonType.Custom)
                {
                    Frame = new CGRect(100, 100, 40, 40),
                };
                //CartButton.Layer.BorderWidth = 1f;
                str3.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);

                var str4 = new UIButton(UIButtonType.Custom)
                {
                    Frame = new CGRect(140, 100, 40, 40),
                };
                //CartButton.Layer.BorderWidth = 1f;
                str4.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);

                var str5 = new UIButton(UIButtonType.Custom)
                {
                    Frame = new CGRect(180, 100, 40, 40),
                };
                //CartButton.Layer.BorderWidth = 1f;
                str5.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);

                scrollview.AddSubviews(str1, str2, str3, str4, str5);

                str1.TouchUpInside += (s, e) => {
                    str5.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str4.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str3.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str2.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str1.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);

                };
                str2.TouchUpInside += (s, e) => {
                    str5.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str4.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str3.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str2.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str1.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);

                };
                str3.TouchUpInside += (s, e) => {
                    str5.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str4.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str3.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str2.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str1.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);

                };
                str4.TouchUpInside += (s, e) => {
                    str5.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str4.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str3.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str2.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str1.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);

                };
                str5.TouchUpInside += (s, e) => {
                    str5.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str4.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str3.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str2.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str1.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);

                };

                UITextView CommentField = new UITextView(new CGRect(20, 200, 330, 150));
                CommentField.Layer.BorderWidth = 1f;
                CommentField.Layer.CornerRadius = 5;
                CommentField.AutoresizingMask = UIViewAutoresizing.All;

                CommentField.Editable = true;

                var SaveComment = new UIButton(UIButtonType.Custom)
                {
                    Frame = new CGRect(40, CommentField.Frame.Y + CommentField.Frame.Height + 20, View.Frame.Width - 80, 40),
                };
                SaveComment.SetTitle("Save Comment", UIControlState.Normal);
                SaveComment.BackgroundColor = UIColor.Blue;
                scrollview.AddSubviews(CommentField, SaveComment);

            }
            //  else { label1.Text = "Review Page"; }
        }
    }
}
