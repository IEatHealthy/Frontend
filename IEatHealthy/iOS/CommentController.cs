using CoreGraphics;
using Foundation;
using System;
using System.IO;
using System.Net;
using UIKit;

namespace IEatHealthy.iOS
{
    public partial class CommentController : UIViewController
    {
        public static AppDelegate App
        {
            get { return (AppDelegate)UIApplication.SharedApplication.Delegate; }
        }

        public CommentController(IntPtr handle) : base(handle)
        {
        }
        public string token="ss";
        public bool isCOmment = false;

        public int rating = 6;
        public override void ViewDidLoad()
        {   
            base.ViewDidLoad();
            if (isCOmment == true)
            {
                

                
                UILabel ratingLabel = new UILabel(new CGRect(20, 40, 200, 30));
                ratingLabel.Text = "Rating";
                ratingLabel.Font = UIFont.FromName("Helvetica-bold", 18f);
                scrollview.AddSubview(ratingLabel);
                //label1.Text = "Comment page";
                var str1 = new UIButton(UIButtonType.Custom)
                {
                    Frame = new CGRect(20, 70, 40, 40),
                };
                //CartButton.Layer.BorderWidth = 1f;
                str1.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);

                var str2 = new UIButton(UIButtonType.Custom)
                {
                    Frame = new CGRect(60, 70, 40, 40),
                };
                //CartButton.Layer.BorderWidth = 1f;
                str2.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);

                var str3 = new UIButton(UIButtonType.Custom)
                {
                    Frame = new CGRect(100, 70, 40, 40),
                };
                //CartButton.Layer.BorderWidth = 1f;
                str3.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);

                var str4 = new UIButton(UIButtonType.Custom)
                {
                    Frame = new CGRect(140, 70, 40, 40),
                };
                //CartButton.Layer.BorderWidth = 1f;
                str4.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);

                var str5 = new UIButton(UIButtonType.Custom)
                {
                    Frame = new CGRect(180, 70, 40, 40),
                };
                //CartButton.Layer.BorderWidth = 1f;
                str5.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);

                scrollview.AddSubviews(str1, str2, str3, str4, str5);

                str1.TouchUpInside += (s, e) =>
                {
                    str5.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str4.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str3.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str2.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str1.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);

                };
                str2.TouchUpInside += (s, e) =>
                {
                    str5.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str4.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str3.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str2.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str1.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);

                };
                str3.TouchUpInside += (s, e) =>
                {
                    str5.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str4.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str3.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str2.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str1.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);

                };
                str4.TouchUpInside += (s, e) =>
                {
                    str5.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str4.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str3.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str2.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str1.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);

                };
                str5.TouchUpInside += (s, e) =>
                {
                    str5.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str4.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str3.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str2.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str1.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);

                };

                UILabel CommentLabel = new UILabel(new CGRect(20, 120, 200, 30));
                CommentLabel.Text = "Comments";
                CommentLabel.Font = UIFont.FromName("Helvetica-bold", 18f);
                scrollview.AddSubview(CommentLabel);

                UITextView CommentField = new UITextView(new CGRect(20, 170, 330, 150));
                CommentField.Layer.BorderWidth = 1f;
                CommentField.Layer.CornerRadius = 5;
                CommentField.Font = UIFont.FromName("Helvetica", 16f);
                CommentField.AutoresizingMask = UIViewAutoresizing.All;

                CommentField.Editable = true;

                var SaveComment = new UIButton(UIButtonType.Custom)
                {
                    Frame = new CGRect(20, CommentField.Frame.Y + CommentField.Frame.Height + 20, View.Frame.Width - 40, 40),
                };
                SaveComment.SetTitle("Save Comment", UIControlState.Normal);
                SaveComment.BackgroundColor = UIColor.Red;//UIColor.FromRGB(244, 95, 66);
                SaveComment.Layer.CornerRadius = 8;
                scrollview.AddSubviews(CommentField, SaveComment);

                SaveComment.TouchUpInside += (s, e) =>
                {

                    //post the rating and comment and go back to the recipedetail page
                    NavigationController.PopViewController(true);
                };
            }


            if (isCOmment == false)
            {
                
                UITextView aa = new UITextView(new CGRect(20, 40, 330, 150));
                aa.Layer.BorderWidth = 1f;
                aa.Layer.CornerRadius = 5;
                aa.Font = UIFont.FromName("Helvetica", 16f);
                aa.AutoresizingMask = UIViewAutoresizing.All;
                scrollview.Add(aa);
               
                 


                UIButton aaa = new UIButton(new CGRect(100, 300, 50, 50));
                aaa.SetTitle("aa button", UIControlState.Normal);
                aaa.Layer.BorderWidth = 1f;
                aaa.BackgroundColor = UIColor.Blue;
                scrollview.AddSubview(aaa);


                //deleating user account

              
                aaa.TouchUpInside += (s, e) =>
                {

                    foreach(string item in App.currentAccount.recipesCreated){
                        aa.Text = aa.Text + item + "\n";
                    }
                   






                };



           
            }
            //  else { label1.Text = "Review Page"; }
           
        }
    }
}

    /*


                    var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info/api/user/aaa/bbb"));
    request.ContentType = "application/JSON";
                    request.Method = "DELETE";
                    try
                    {
                        var response = request.GetResponse() as HttpWebResponse;

    string myResponse = "";
                            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                            {

                                myResponse = sr.ReadToEnd();
                            UITextView mm = new UITextView(new CGRect(20, 500, 100, 20));
    mm.Layer.BorderWidth = 1f;
                            mm.Layer.CornerRadius = 5;
                            mm.Font = UIFont.FromName("Helvetica", 16f);
                            mm.AutoresizingMask = UIViewAutoresizing.All;
                            mm.Text = response.StatusCode.ToString();
                            scrollview.AddSubview(mm);

                            }
                        }

                    catch (WebException err)
                    {

                        UITextView mm = new UITextView(new CGRect(20, 400, 100, 20));
mm.Layer.BorderWidth = 1f;
                        mm.Layer.CornerRadius = 5;
                        mm.Font = UIFont.FromName("Helvetica", 16f);
                        mm.AutoresizingMask = UIViewAutoresizing.All;
                        mm.Text = err.Status.ToString();
                        scrollview.AddSubview(mm);
                       
                    }
                };

               */  

                //deleating user account