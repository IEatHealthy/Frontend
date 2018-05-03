using CoreGraphics;
using Foundation;
using System;
using System.IO;
using System.Net;
using UIKit;
using System.Collections.Generic;
using Newtonsoft.Json;

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
        public ItemDetailViewModel ViewModel { get; set; }

        public string token = "ss";
        public bool isCOmment = false;
        UITextView CommentField;
        public int ratingvalue = 0;
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
                    ratingvalue = 1;

                };
                str2.TouchUpInside += (s, e) =>
                {
                    str5.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str4.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str3.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str2.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str1.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    ratingvalue = 2;

                };
                str3.TouchUpInside += (s, e) =>
                {
                    str5.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str4.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str3.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str2.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str1.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    ratingvalue = 3;

                };
                str4.TouchUpInside += (s, e) =>
                {
                    str5.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                    str4.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str3.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str2.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str1.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    ratingvalue = 4;

                };
                str5.TouchUpInside += (s, e) =>
                {
                    str5.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str4.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str3.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str2.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    str1.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                    ratingvalue = 5;

                };

                UILabel CommentLabel = new UILabel(new CGRect(20, 120, 200, 30));
                CommentLabel.Text = "Comments";
                CommentLabel.Font = UIFont.FromName("Helvetica-bold", 18f);
                scrollview.AddSubview(CommentLabel);

                CommentField = new UITextView(new CGRect(20, 170, 330, 150));
                CommentField.Layer.BorderWidth = 1f;
                CommentField.Layer.CornerRadius = 5;
                CommentField.Font = UIFont.FromName("Helvetica", 16f);
                CommentField.AutoresizingMask = UIViewAutoresizing.All;

                getreview();
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
                    postRating();
                    postComment();
                    NavigationController.PopViewController(true);
                };
            }


            if (isCOmment == false)
            {

                /*

                var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info/api/recipe/{0}/reviews?token={1}", ViewModel.Item.stringId, App.currentAccount.JWTToken));
                request.ContentType = "application/JSON";
                request.Method = "GET";


                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                string aResponse = "";
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {

                    aResponse = sr.ReadToEnd();

                    var newitem = JsonConvert.DeserializeObject<List<UserReview>>(aResponse);
                    UITextView aads = new UITextView(new CGRect(20, 200, 300, 200));
                    foreach (UserReview item in newitem){
                        aads.Text = aads.Text + item.userReview + "\n";
                    }
                    scrollview.AddSubview(aads);





                }

                var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info/api/recipe/{0}/review?email={1}&token={2}", ViewModel.Item.stringId, App.currentAccount.email, App.currentAccount.JWTToken));
                request.ContentType = "application/JSON";
                request.Method = "GET";


                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                string aResponse = "";
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {

                    aResponse = sr.ReadToEnd();

                    //var newitem = JsonConvert.DeserializeObject<UserReview>(aResponse);
                    UITextView aads = new UITextView(new CGRect(20, 200, 300, 200));

                    aads.Text = aResponse;//newitem.userReview;

                    scrollview.AddSubview(aads);
*/
                UITextField searchfield = new UITextField(new CGRect (20, 30, 200, 30));
                searchfield.Placeholder = "search";
                scrollview.AddSubview(searchfield);

                var searchbutton = new UIButton(UIButtonType.ContactAdd)
                {
                    Frame = new CGRect(250, 30, 30, 30),
                };
                scrollview.AddSubview(searchbutton);

                searchbutton.TouchUpInside += (s, e) =>
                {
                    string aa = searchfield.Text;
                    aa = aa.Replace(" ", "%20");
                    //string inputToSearch;
                    //string userInput = searchfield.Text;

                    //for (int i = 0; i < userInput.Length(); i++) {
                        

                    var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info/api/recipe/{0}?token={1}", aa, App.currentAccount.JWTToken));
                    request.ContentType = "application/JSON";
                    request.Method = "GET";


                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    string aResponse = "";
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {

                        aResponse = sr.ReadToEnd();

                        var newitem = JsonConvert.DeserializeObject<List<Item>>(aResponse);

                        UITextView aads = new UITextView(new CGRect(20, 80, 300, 500));

                        aads.Text =aResponse.Replace(",", "," + System.Environment.NewLine);;
                        scrollview.AddSubview(aads);





                    }
                };
            }

                }



        public async void getreview()
        {
            var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info/api/recipe/{0}/review?email={1}&token={2}", ViewModel.Item.stringId, App.currentAccount.email, App.currentAccount.JWTToken));
            request.ContentType = "application/JSON";
            request.Method = "GET";


            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string aResponse = "";
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {

                aResponse = sr.ReadToEnd();

                //var newitem = JsonConvert.DeserializeObject<UserReview>(aResponse);
                UITextView aads = new UITextView(new CGRect(20, 200, 300, 200));

                aads.Text = aResponse;//newitem.userReview;

                scrollview.AddSubview(aads);





            }
        }
        public async void postRating()
        {
            var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info/api/recipe/{0}/rate?token={1}", ViewModel.Item.stringId, App.currentAccount.JWTToken));

            request.ContentType = "application/json";
            request.Method = "POST";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new UserRating
                {
                    userEmail = App.currentAccount.email,
                    userRating = ratingvalue,

                });

                streamWriter.Write(json);
            }

            var response1 = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response1.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
        public async void postComment()
        {
            var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info/api/recipe/{0}/review?token={1}", ViewModel.Item.stringId, App.currentAccount.JWTToken));

            request.ContentType = "application/json";
            request.Method = "POST";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new UserReview
                {
                    userEmail = App.currentAccount.email,
                    userReview=CommentField.Text,

                });

                streamWriter.Write(json);
            }

            var response1 = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response1.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }


    }
}
   
        /*          



                    NavigationController.PopViewController(true);
                };
            }


            if (isCOmment == false)
            {

                /*

                var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info/api/recipe/{0}/reviews?token={1}", ViewModel.Item.stringId, App.currentAccount.JWTToken));
                request.ContentType = "application/JSON";
                request.Method = "GET";


                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                string aResponse = "";
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {

                    aResponse = sr.ReadToEnd();

                    var newitem = JsonConvert.DeserializeObject<List<UserReview>>(aResponse);
                    UITextView aads = new UITextView(new CGRect(20, 200, 300, 200));
                    foreach (UserReview item in newitem){
                        aads.Text = aads.Text + item.userReview + "\n";
                    }
                    scrollview.AddSubview(aads);





                }
                */
               


/*
public async void getrating()
{
    var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info/api/recipe/{0}/rating?email={1}&token={2}", ViewModel.Item.stringId, App.currentAccount.email, App.currentAccount.JWTToken));
    request.ContentType = "application/JSON";
    request.Method = "GET";


    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
    string aResponse = "";
    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
    {

        aResponse = sr.ReadToEnd();

        //var newitem = JsonConvert.DeserializeObject<UserReview>(aResponse);
        UITextView aads = new UITextView(new CGRect(20, 200, 300, 200));

        aads.Text = aResponse;//newitem.userReview;

        scrollview.AddSubview(aads);





    }
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


//getting the bookmarked recipes
                /*
                List<Item> items = new List<Item>();
                aaa.TouchUpInside += (s, e) =>
                {   
                    foreach (string item in App.currentAccount.bookmarkedRecipes)
                        {
                        var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info/api/recipe/id?id={0}&token={1}",item, App.currentAccount.JWTToken));
                            request.ContentType = "application/JSON";
                            request.Method = "GET";

                           
                                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                                string aResponse = "";
                        using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                        {

                            aResponse = sr.ReadToEnd();
                            //storing token in CurrentAccount instance of type UserAccount

                            // App.currentAccount.JWTToken = aResponse;

                            //   App.currentAccount.JWTToken = aResponse;

                            //  objectret = aResponse;
                            // Item newitem= JsonConvert.DeserializeObject<Item>(json);
                            Item newitem = JsonConvert.DeserializeObject<Item>(aResponse);
                            aa.Text = aa.Text + newitem.name + "\n";
                            items.Add(newitem);

                        }

                        }

*/

