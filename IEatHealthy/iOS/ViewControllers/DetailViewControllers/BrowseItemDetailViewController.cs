using System;
using System.Linq;
using CoreGraphics;
using Foundation;
using UIKit;
using System.Collections.Generic;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace IEatHealthy.iOS
{
    public partial class BrowseItemDetailViewController : UIViewController
    {
        public ItemDetailViewModel ViewModel { get; set; }
        public List<UITextView> IngrediantList = new List<UITextView>();
        public List<UITextView> StepList = new List<UITextView>();
        public List<UILabel> NutrationalFactsList = new List<UILabel>();
        public static AppDelegate App
        {
            get { return (AppDelegate)UIApplication.SharedApplication.Delegate; }
        }

        public BrowseItemDetailViewController(IntPtr handle) : base(handle) { }
        public int itemsss = 0;
        public int reviewCount = 0;
        public double ratingCount = 0;
        public bool searched = false;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //   Title = ViewModel.Item.Text;

           
          //NavigationItem.BackBarButtonItem.Enabled = true;

            scrollView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;

            UILabel recipename = new UILabel(new CGRect(0, 10, View.Frame.Width, 30));
            recipename.Text = ViewModel.Item.name;
            recipename.TextAlignment = UITextAlignment.Center;
            recipename.Font = UIFont.FromName("Helvetica-Bold", 20f);
            recipename.AutoresizingMask = UIViewAutoresizing.All;
            scrollView.AddSubview(recipename);

            UILabel bylabel = new UILabel(new CGRect(10, 50, 200, 30));
            bylabel.Text = "by " + ViewModel.Item.author;
            bylabel.Font = UIFont.FromName("Helvetica", 15f);

            scrollView.AddSubview(bylabel);
            gettotalRatingt();

            var str1 = new UIButton(UIButtonType.Custom)
            {
                Frame = new CGRect(10, 90, 30,30),
            };
            str1.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);

            var str2 = new UIButton(UIButtonType.Custom)
            {
                Frame = new CGRect(40, 90, 30, 30),
            };
            str2.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);

            var str3 = new UIButton(UIButtonType.Custom)
            {
                Frame = new CGRect(70, 90, 30, 30),
            };
            str3.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);

            var str4 = new UIButton(UIButtonType.Custom)
            {
                Frame = new CGRect(100, 90, 30,30),
            };
            str4.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);

            var str5 = new UIButton(UIButtonType.Custom)
            {
                Frame = new CGRect(130, 90, 30, 30),
            };
            str5.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);

            if(ratingCount>1&&ratingCount<1.7){
                str1.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                str2.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                str3.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                str4.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                str5.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
            
            }
            if (ratingCount>=1.7  && ratingCount < 2.7) { 
                str1.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                str2.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                str3.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                str4.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                str5.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
            }
            if (ratingCount >= 2.7 && ratingCount < 3.7) {
                str1.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                str2.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                str3.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                str4.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
                str5.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
            }
            if (ratingCount >=3.7 && ratingCount < 4.7) {
                str1.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                str2.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                str3.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                str4.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                str5.SetImage(UIImage.FromBundle("str1"), UIControlState.Normal);
            }
            if (ratingCount > 4.7 && ratingCount <= 5) {
                str1.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                str2.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                str3.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                str4.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
                str5.SetImage(UIImage.FromBundle("str2"), UIControlState.Normal);
            }


            
            scrollView.AddSubviews(str1, str2, str3, str4, str5);


            ReviewButton.Frame = new CGRect(View.Frame.Width - 160, 90, 150, 20);
            getCommentCount();
            ReviewButton.Font = UIFont.FromName("Helvetica", 15f);
            string aa = reviewCount.ToString() + " reviews";
            ReviewButton.SetTitle(aa, UIControlState.Normal);
            ReviewButton.SetTitleColor(UIColor.FromRGB(66, 134, 244), UIControlState.Normal);
            scrollView.AddSubview(ReviewButton);



            CommentButton.Frame = new CGRect(View.Frame.Width - 160, 110, 150, 20);
            CommentButton.Font = UIFont.FromName("Helvetica", 15f);
            CommentButton.SetTitle("Rate/Comment", UIControlState.Normal);
            CommentButton.SetTitleColor(UIColor.FromRGB(66, 134, 244), UIControlState.Normal);
            scrollView.AddSubview(CommentButton);

            var Bookmark = new UIButton(UIButtonType.Custom)
            {
                Frame = new CGRect(View.Frame.Width - 60, 50, 40, 50),

             };

            Bookmark.SetImage(UIImage.FromBundle("bookmarkicon"), UIControlState.Normal);
            scrollView.AddSubview(Bookmark);
            Bookmark.TouchUpInside += (sender, e) => {
                App.currentAccount.bookmarkedRecipes.Add(ViewModel.Item.stringId);
                var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info/api/recipe/bookmark?recipeId={0}&email={1}&token={2}",ViewModel.Item.stringId, App.currentAccount.email, App.currentAccount.JWTToken));
                request.ContentType = "application/JSON";
                request.Method = "POST";
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    try
                    {
                        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                        using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                        {
                            var result = sr.ReadToEnd();
                            var okAlertController = UIAlertController.Create("Success", "Recipe bookmarked", UIAlertControllerStyle.Alert);
                            okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                            PresentViewController(okAlertController, true, null);
                        }
                    }
                    catch (System.Net.WebException)
                    {
                        var okAlertController = UIAlertController.Create("Success", ViewModel.Item.id, UIAlertControllerStyle.Alert);
                        okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                        PresentViewController(okAlertController, true, null);
                    }
                }
            };

            UISegmentedControl RecipeControl = new UISegmentedControl();
            RecipeControl.Frame = new CGRect(0, 140, View.Bounds.Size.Width, 40);
            RecipeControl.BackgroundColor = UIColor.White;
            RecipeControl.TintColor = UIColor.Clear;
            RecipeControl.InsertSegment("Detail", 0, false);
            RecipeControl.InsertSegment("Ingredients", 1, false);
            RecipeControl.InsertSegment("Steps", 2, false);

            RecipeControl.SetTitleTextAttributes(new UITextAttributes()
            {
                TextColor = UIColor.Black,
                Font = UIFont.FromName("Helvetica-Light", 14f),
                TextShadowColor = UIColor.Clear
            }, UIControlState.Normal);

            RecipeControl.SetTitleTextAttributes(new UITextAttributes()
            {
                TextColor = UIColor.Red,
                Font = UIFont.FromName("Helvetica-Light", 14f),
                TextShadowColor = UIColor.Clear
            }, UIControlState.Selected);

            RecipeControl.Layer.BorderColor = (UIColor.White).CGColor;
            RecipeControl.Layer.BorderWidth = 0f;
            RecipeControl.SelectedSegment = 0;

          
            var imageBytes = Convert.FromBase64String(ViewModel.Item.foodImage.data);
            var imagedata = NSData.FromArray(imageBytes);
            var uiimage = UIImage.LoadFromData(imagedata);

            float x = (float)uiimage.Size.Width;
            float y = (float)uiimage.Size.Height;
            float ratio = x / y;
            y = (float)((View.Frame.Width - 80) / ratio);

            UIImageView recipeImage = new UIImageView(new CGRect(40, 180, View.Frame.Width - 80, y));
            recipeImage.Image = uiimage;
            scrollView.AddSubview(recipeImage);
            scrollView.AddSubview(RecipeControl);

            UITextView DescrivtionView = new UITextView(new CGRect(30, recipeImage.Frame.Y + recipeImage.Frame.Height + 10, View.Frame.Width - 60, 40));
            DescrivtionView.Text = ViewModel.Item.description;
            DescrivtionView.AutoresizingMask = UIViewAutoresizing.All;
            DescrivtionView.Font = UIFont.FromName("Helvetica-bold", 16f);
            DescrivtionView.SizeToFit();
            DescrivtionView.Editable = false;
            DescrivtionView.ScrollEnabled = false;
            DescrivtionView.Text = ViewModel.Item.description;
            scrollView.AddSubview(DescrivtionView);

            UILabel graybox = new UILabel(new CGRect(0, DescrivtionView.Frame.Y + DescrivtionView.Frame.Height + 10, View.Frame.Width, 5));
            graybox.BackgroundColor = UIColor.Gray;
            graybox.Layer.CornerRadius = -10;
            scrollView.AddSubview(graybox);

            UILabel preptimelabel = new UILabel(new CGRect(20, graybox.Frame.Y + 10, 100, 20));
            preptimelabel.Font = UIFont.FromName("Helvetica", 14f);

            preptimelabel.Text = "Prep Time";
            UILabel preptime = new UILabel(new CGRect(140, graybox.Frame.Y + 10, 100, 20));
            preptime.Text = ViewModel.Item.prepTime + " Min";
            preptime.Font = UIFont.FromName("Helvetica", 14f);


            UILabel CooktimeLabel = new UILabel(new CGRect(20, preptimelabel.Frame.Y + 20, 100, 20));
            CooktimeLabel.Text = "Cook Time";
            CooktimeLabel.Font = UIFont.FromName("Helvetica", 14f);

            UILabel Cooktime = new UILabel(new CGRect(140, preptimelabel.Frame.Y + 20, 100, 20));
            Cooktime.Text = ViewModel.Item.cookTime + " Min";
            Cooktime.Font = UIFont.FromName("Helvetica", 14f);

            UILabel Readyinlabel = new UILabel(new CGRect(20, Cooktime.Frame.Y + 20, 100, 20));
            Readyinlabel.Text = "Ready In";
            Readyinlabel.Font = UIFont.FromName("Helvetica", 14f);

            UILabel Readyin = new UILabel(new CGRect(140, Cooktime.Frame.Y + 20, 100, 20));
            Readyin.Text = ViewModel.Item.prepTime + " Min";
            Readyin.Font = UIFont.FromName("Helvetica", 14f);


            string ab = "";
            int a = ViewModel.Item.difficulty;
            if (a == 1) { ab = "Easy"; }
            if (a == 2) { ab = "Medium"; }
            if (a == 3) { ab = "Hard"; }

            UILabel difficultylabel = new UILabel(new CGRect(20, Readyin.Frame.Y + 20, 100, 20));
            difficultylabel.Text = "Difficulty ";
            difficultylabel.Font = UIFont.FromName("Helvetica", 14f);


            UILabel difficulty = new UILabel(new CGRect(140, Readyin.Frame.Y + 20, 100, 20));
            difficulty.Text = ab;
            difficulty.Font = UIFont.FromName("Helvetica", 14f);

            UILabel graybox1 = new UILabel(new CGRect(0, difficulty.Frame.Y + 30, View.Frame.Width, 5));
            graybox1.BackgroundColor = UIColor.Gray;
            scrollView.AddSubview(graybox1);


            UILabel NutrationalFactsLabel = new UILabel(new CGRect(20, graybox1.Frame.Y + 10, 300, 30));
            NutrationalFactsLabel.Text = "Nutrition Facts";
            NutrationalFactsLabel.Font = UIFont.FromName("Helvetica-bold", 22f);
            NutrationalFactsList.Add(NutrationalFactsLabel);

            UILabel ServingSizeLabel = new UILabel(new CGRect(20, NutrationalFactsLabel.Frame.Y + 30, 300, 25));
            ServingSizeLabel.Text = "Serving size " + ViewModel.Item.servings.ToString();
            ServingSizeLabel.Font = UIFont.FromName("Helvetica", 17f);
            NutrationalFactsList.Add(ServingSizeLabel);

            UILabel graybox11 = new UILabel(new CGRect(0, ServingSizeLabel.Frame.Y + 26, View.Frame.Width, 2));
            graybox11.BackgroundColor = UIColor.Gray;

            NutrationalFactsList.Add(graybox11);

            UILabel AmountLabel = new UILabel(new CGRect(20, graybox11.Frame.Y + 4, 300, 30));
            AmountLabel.Text = "Amount Per Serving";//+ViewModel.Item.calorieCount;
            AmountLabel.Font = UIFont.FromName("Helvetica-bold", 15f);
            NutrationalFactsList.Add(AmountLabel);

            UILabel graybox12 = new UILabel(new CGRect(0, AmountLabel.Frame.Y + 26, View.Frame.Width, 2));
            graybox12.BackgroundColor = UIColor.Gray;
            NutrationalFactsList.Add(graybox12);


            UILabel CalorieLabel = new UILabel(new CGRect(20, graybox12.Frame.Y + 4, 300, 30));
            CalorieLabel.Text = "Calories "+ViewModel.Item.calories.ToString();
            CalorieLabel.Font = UIFont.FromName("Helvetica", 15f);
            NutrationalFactsList.Add(CalorieLabel);

            UILabel graybox13 = new UILabel(new CGRect(0, CalorieLabel.Frame.Y + 30, View.Frame.Width, 4));
            graybox13.BackgroundColor = UIColor.Gray;
            NutrationalFactsList.Add(graybox13);


            UILabel DailyValue = new UILabel(new CGRect(View.Frame.Width - 170, graybox13.Frame.Y + 4, 150, 30));
            DailyValue.Text = "% Daily Value ";
            DailyValue.Font = UIFont.FromName("Helvetica", 15f);
            DailyValue.TextAlignment = UITextAlignment.Right;
            NutrationalFactsList.Add(DailyValue);

            UILabel graybox14 = new UILabel(new CGRect(0, DailyValue.Frame.Y + 30, View.Frame.Width, 2));
            graybox14.BackgroundColor = UIColor.Gray;
            NutrationalFactsList.Add(graybox14);

            UILabel Fatlabel = new UILabel(new CGRect(20, graybox14.Frame.Y + 4, 300, 20));
            Fatlabel.Text = "Total Fat "+ViewModel.Item.fat.ToString();
            Fatlabel.Font = UIFont.FromName("Helvetica-bold", 15f);
            NutrationalFactsList.Add(Fatlabel);

            UILabel fatper = new UILabel(new CGRect(View.Frame.Width - 50, graybox14.Frame.Y + 4, 30, 20));
            fatper.Text = "0 %";//+ViewModel.Item.calorieCount;
            fatper.Font = UIFont.FromName("Helvetica", 15f);
            NutrationalFactsList.Add(fatper);

            UILabel graybox15 = new UILabel(new CGRect(0, Fatlabel.Frame.Y + 20, View.Frame.Width, 2));
            graybox15.BackgroundColor = UIColor.Gray;
            NutrationalFactsList.Add(graybox15);

            UILabel satFatlabel = new UILabel(new CGRect(40, graybox15.Frame.Y + 4, 300, 20));
            satFatlabel.Text = "Saturated Fat "+ViewModel.Item.fat.ToString();
            satFatlabel.Font = UIFont.FromName("Helvetica", 15f);
            NutrationalFactsList.Add(satFatlabel);

            UILabel graybox16 = new UILabel(new CGRect(0, satFatlabel.Frame.Y + 20, View.Frame.Width, 2));
            graybox16.BackgroundColor = UIColor.Gray;
            NutrationalFactsList.Add(graybox16);

            UILabel Transfat = new UILabel(new CGRect(40, graybox16.Frame.Y + 4, 300, 20));
            Transfat.Text = "Trans Fat  "+ViewModel.Item.fat.ToString();
            Transfat.Font = UIFont.FromName("Helvetica", 15f);
            NutrationalFactsList.Add(Transfat);

            UILabel Transper = new UILabel(new CGRect(View.Frame.Width - 50, graybox16.Frame.Y + 4, 30, 20));
            Transper.Text = "0 %";//+ViewModel.Item.calorieCount;
            Transper.Font = UIFont.FromName("Helvetica", 15f);
            NutrationalFactsList.Add(Transper);

            UILabel graybox17 = new UILabel(new CGRect(0, Transfat.Frame.Y + 20, View.Frame.Width, 2));
            graybox17.BackgroundColor = UIColor.Gray;
            NutrationalFactsList.Add(graybox17);

            UILabel cholesLabel = new UILabel(new CGRect(20, graybox17.Frame.Y + 4, 300, 20));
            cholesLabel.Text = "Cholesterol "+ViewModel.Item.cholestrol.ToString();
            cholesLabel.Font = UIFont.FromName("Helvetica-bold", 15f);
            NutrationalFactsList.Add(cholesLabel);

            UILabel cholper = new UILabel(new CGRect(View.Frame.Width - 50, graybox17.Frame.Y + 4, 30, 20));
            cholper.Text = "0 %";//+ViewModel.Item.calorieCount;
            cholper.Font = UIFont.FromName("Helvetica", 15f);
            NutrationalFactsList.Add(cholper);

            UILabel graybox18 = new UILabel(new CGRect(0, cholesLabel.Frame.Y + 20, View.Frame.Width, 2));
            graybox18.BackgroundColor = UIColor.Gray;
            NutrationalFactsList.Add(graybox18);

            UILabel SodiiumLabel = new UILabel(new CGRect(20, graybox18.Frame.Y + 4, 300, 20));
            SodiiumLabel.Text = "Sodium "+ViewModel.Item.sodium.ToString();
            SodiiumLabel.Font = UIFont.FromName("Helvetica-bold", 15f);
            NutrationalFactsList.Add(SodiiumLabel);

            UILabel sodper = new UILabel(new CGRect(View.Frame.Width - 50, graybox18.Frame.Y + 4, 30, 20));
            sodper.Text = "0 %";//+ViewModel.Item.calorieCount;
            sodper.Font = UIFont.FromName("Helvetica", 15f);
            NutrationalFactsList.Add(sodper);

            UILabel graybox19 = new UILabel(new CGRect(0, SodiiumLabel.Frame.Y + 20, View.Frame.Width, 2));
            graybox19.BackgroundColor = UIColor.Gray;
            NutrationalFactsList.Add(graybox19);

            UILabel Carblabel = new UILabel(new CGRect(20, graybox19.Frame.Y + 4, 300, 20));
            Carblabel.Text = "Total Carbohydrate "+ViewModel.Item.carbohydrate.ToString();
            Carblabel.Font = UIFont.FromName("Helvetica-bold", 15f);
            NutrationalFactsList.Add(Carblabel);

            UILabel carbper = new UILabel(new CGRect(View.Frame.Width - 50, graybox19.Frame.Y + 4, 30, 20));
            carbper.Text = "0 %";//+ViewModel.Item.calorieCount;
            carbper.Font = UIFont.FromName("Helvetica", 15f);
            NutrationalFactsList.Add(carbper);

            UILabel graybox20 = new UILabel(new CGRect(0, Carblabel.Frame.Y + 20, View.Frame.Width, 2));
            graybox20.BackgroundColor = UIColor.Gray;
            NutrationalFactsList.Add(graybox20);

            UILabel Fiberlabel = new UILabel(new CGRect(40, graybox20.Frame.Y + 4, 300, 20));
            Fiberlabel.Text = "Fiber  0g";//+ViewModel.Item.calorieCount;
            Fiberlabel.Font = UIFont.FromName("Helvetica", 15f);
            NutrationalFactsList.Add(Fiberlabel);

            UILabel fiberper = new UILabel(new CGRect(View.Frame.Width - 50, graybox20.Frame.Y + 4, 30, 20));
            fiberper.Text = "0 %";//+ViewModel.Item.calorieCount;
            fiberper.Font = UIFont.FromName("Helvetica", 15f);
            NutrationalFactsList.Add(fiberper);

            UILabel graybox21 = new UILabel(new CGRect(0, Fiberlabel.Frame.Y + 20, View.Frame.Width, 2));
            graybox21.BackgroundColor = UIColor.Gray;
            NutrationalFactsList.Add(graybox21);

            UILabel Sugerlabel = new UILabel(new CGRect(40, graybox21.Frame.Y + 4, 300, 20));
            Sugerlabel.Text = "Sugars  0g";//+ViewModel.Item.calorieCount;
            Sugerlabel.Font = UIFont.FromName("Helvetica", 15f);
            NutrationalFactsList.Add(Sugerlabel);

            UILabel graybox22 = new UILabel(new CGRect(0, Sugerlabel.Frame.Y + 20, View.Frame.Width, 2));
            graybox22.BackgroundColor = UIColor.Gray;
            NutrationalFactsList.Add(graybox22);

            UILabel ProteinLabel = new UILabel(new CGRect(20, graybox22.Frame.Y + 4, 300, 20));
            ProteinLabel.Text = "Protein 0g";//+ViewModel.Item.calorieCount;
            ProteinLabel.Font = UIFont.FromName("Helvetica-bold", 15f);
            NutrationalFactsList.Add(ProteinLabel);

            UILabel graybox23 = new UILabel(new CGRect(0, ProteinLabel.Frame.Y + 20, View.Frame.Width, 4));
            graybox23.BackgroundColor = UIColor.Gray;
            NutrationalFactsList.Add(graybox23);

            UILabel Vitalabel = new UILabel(new CGRect(20, graybox23.Frame.Y + 4, 300, 20));
            Vitalabel.Text = "Vitamin A";//+ViewModel.Item.calorieCount;
            Vitalabel.Font = UIFont.FromName("Helvetica-bold", 15f);
            NutrationalFactsList.Add(Vitalabel);

            UILabel VitaPer = new UILabel(new CGRect(View.Frame.Width - 50, graybox23.Frame.Y + 4, 30, 20));
            VitaPer.Text = "0 %";//+ViewModel.Item.calorieCount;
            VitaPer.Font = UIFont.FromName("Helvetica", 15f);
            NutrationalFactsList.Add(VitaPer);

            UILabel graybox24 = new UILabel(new CGRect(0, Vitalabel.Frame.Y + 20, View.Frame.Width, 2));
            graybox24.BackgroundColor = UIColor.Gray;
            NutrationalFactsList.Add(graybox24);

            UILabel Vitclabel = new UILabel(new CGRect(20, graybox24.Frame.Y + 4, 300, 20));
            Vitclabel.Text = "Vitamin C";//+ViewModel.Item.calorieCount;
            Vitclabel.Font = UIFont.FromName("Helvetica-bold", 15f);
            NutrationalFactsList.Add(Vitclabel);

            UILabel VitcPer = new UILabel(new CGRect(View.Frame.Width - 50, graybox24.Frame.Y + 4, 30, 20));
            VitcPer.Text = "0 %";//+ViewModel.Item.calorieCount;
            VitcPer.Font = UIFont.FromName("Helvetica", 15f);
            NutrationalFactsList.Add(VitcPer);

            UILabel graybox25 = new UILabel(new CGRect(0, Vitclabel.Frame.Y + 20, View.Frame.Width, 2));
            graybox25.BackgroundColor = UIColor.Gray;
            NutrationalFactsList.Add(graybox25);

            UILabel Vitdlabel = new UILabel(new CGRect(20, graybox25.Frame.Y + 4, 300, 20));
            Vitdlabel.Text = "Vitamin D";//+ViewModel.Item.calorieCount;
            Vitdlabel.Font = UIFont.FromName("Helvetica-bold", 15f);
            NutrationalFactsList.Add(Vitdlabel);

            UILabel VitdPer = new UILabel(new CGRect(View.Frame.Width - 50, graybox25.Frame.Y + 4, 30, 20));
            VitdPer.Text = "0 %";//+ViewModel.Item.calorieCount;
            VitdPer.Font = UIFont.FromName("Helvetica", 15f);
            NutrationalFactsList.Add(VitdPer);

            UILabel graybox26 = new UILabel(new CGRect(0, Vitdlabel.Frame.Y + 20, View.Frame.Width, 2));
            graybox26.BackgroundColor = UIColor.Gray;
            NutrationalFactsList.Add(graybox26);

            UILabel Ironlabel = new UILabel(new CGRect(20, graybox26.Frame.Y + 4, 300, 20));
            Ironlabel.Text = "Iron";//+ViewModel.Item.calorieCount;
            Ironlabel.Font = UIFont.FromName("Helvetica-bold", 15f);
            NutrationalFactsList.Add(Ironlabel);

            UILabel ironper = new UILabel(new CGRect(View.Frame.Width - 50, graybox26.Frame.Y + 4, 30, 20));
            ironper.Text = "0 %";//+ViewModel.Item.calorieCount;
            ironper.Font = UIFont.FromName("Helvetica", 15f);
            NutrationalFactsList.Add(ironper);

            UILabel graybox27 = new UILabel(new CGRect(0, ironper.Frame.Y + 20, View.Frame.Width, 2));
            graybox27.BackgroundColor = UIColor.Gray;
            NutrationalFactsList.Add(graybox27);

            UILabel Potlabel = new UILabel(new CGRect(20, graybox27.Frame.Y + 4, 300, 20));
            Potlabel.Text = "Potassium";//+ViewModel.Item.calorieCount;
            Potlabel.Font = UIFont.FromName("Helvetica-bold", 15f);
            NutrationalFactsList.Add(Potlabel);

            UILabel potper = new UILabel(new CGRect(View.Frame.Width - 50, graybox27.Frame.Y + 4, 30, 20));
            potper.Text = "0 %";//+ViewModel.Item.calorieCount;
            potper.Font = UIFont.FromName("Helvetica", 15f);
            NutrationalFactsList.Add(potper);






            foreach (UILabel item in NutrationalFactsList)
            {
                scrollView.AddSubview(item);
            }



            scrollView.AddSubviews(preptime, preptimelabel, Cooktime, CooktimeLabel, Readyin, Readyinlabel, difficulty, difficultylabel, graybox1);





            scrollView.ContentSize = new CGSize(View.Frame.Width, potper.Frame.Y + 40);

            int YforIngredient = (int)(recipeImage.Frame.Y + 10);


            //CartButton.Layer.BorderWidth = 1f;
            Cartbutton.Frame = new CGRect(View.Frame.Width - 45, YforIngredient, 30, 20);
            Cartbutton.SetImage(UIImage.FromBundle("CartTab"), UIControlState.Normal);
            Cartbutton.TintColor = UIColor.Red;
            Cartbutton.RemoveFromSuperview();




            YforIngredient += 30;

         
            foreach (IngredientItem item in ViewModel.Item.ingredients)
                {

                    UITextView label2 = new UITextView(new System.Drawing.RectangleF(20, YforIngredient, 350, 30));
                    //label.Placeholder = " Step " + i.ToString();
                    //  label2.Layer.BorderWidth = 0.1f;
                    label2.Layer.CornerRadius = 8;
                    label2.Font = UIFont.FromName("Helvetica", 14f);

                    label2.ScrollEnabled = false;
                    label2.Editable = false;
                label2.Text = item.desc;
                    label2.AutoresizingMask = UIViewAutoresizing.All;

                    IngrediantList.Add(label2);
                    YforIngredient += (int)label2.Frame.Height;


                }
                


            int Yforstep = (int)(recipeImage.Frame.Y + 10);
            foreach (string item in ViewModel.Item.steps)
            {
                UITextView label2 = new UITextView(new System.Drawing.RectangleF(20, Yforstep, 350, 1));
                //label.Placeholder = " Step " + i.ToString();
                //   label2.Layer.BorderWidth = 0.1f;
                label2.Font = UIFont.FromName("Helvetica", 14f);
                label2.Layer.CornerRadius = 8;
                label2.Text = item;
                label2.AutoresizingMask = UIViewAutoresizing.All;
                label2.SizeToFit();
                label2.ScrollEnabled = false;
                label2.Editable = false;

                StepList.Add(label2);
                Yforstep += (int)label2.Frame.Height;

            }




            int previousIndex = 0;
            RecipeControl.ValueChanged += (sender, e) =>
            {

                var index = RecipeControl.SelectedSegment;

                if (index == 0)
                {

                    if (previousIndex == 1)
                    {
                        foreach (UITextView item in IngrediantList)
                        {
                            item.RemoveFromSuperview();

                        }
                        Cartbutton.RemoveFromSuperview();

                    }
                    if (previousIndex == 2)
                    {
                        foreach (UITextView item in StepList)
                        {
                            item.RemoveFromSuperview();

                        }
                    }
                    scrollView.AddSubviews(graybox, recipeImage, DescrivtionView, preptime, preptimelabel, Cooktime, CooktimeLabel, Readyin, Readyinlabel, difficulty, difficultylabel, graybox1, NutrationalFactsLabel);
                    scrollView.ContentSize = new CGSize(View.Frame.Width, CalorieLabel.Frame.Y + 20);
                    foreach (UILabel item in NutrationalFactsList)
                    {
                        scrollView.AddSubview(item);
                    }
                    previousIndex = 0;


                }
                if (index == 1)
                {

                    if (previousIndex == 0)
                    {
                        recipeImage.RemoveFromSuperview();
                        DescrivtionView.RemoveFromSuperview();
                        preptime.RemoveFromSuperview();
                        preptimelabel.RemoveFromSuperview();
                        Cooktime.RemoveFromSuperview();
                        CooktimeLabel.RemoveFromSuperview();
                        Readyin.RemoveFromSuperview();
                        Readyinlabel.RemoveFromSuperview();
                        difficulty.RemoveFromSuperview();
                        graybox.RemoveFromSuperview();
                        difficultylabel.RemoveFromSuperview();
                        graybox1.RemoveFromSuperview();
                        NutrationalFactsLabel.RemoveFromSuperview();
                        NutrationalFactsLabel.RemoveFromSuperview();
                        foreach (UILabel item in NutrationalFactsList)
                        {
                            item.RemoveFromSuperview();
                        }


                    }
                    if (previousIndex == 2)
                    {
                        foreach (UITextView item in StepList)
                        {
                            item.RemoveFromSuperview();

                        }

                    }

                    foreach (UITextView item in IngrediantList)
                    {
                        scrollView.AddSubview(item);

                    }
                    scrollView.AddSubview(Cartbutton);
                    scrollView.ContentSize = new CGSize(View.Frame.Width, YforIngredient + 20);
                    previousIndex = 1;
                }

                if (index == 2)
                {

                    if (previousIndex == 0)
                    {
                        recipeImage.RemoveFromSuperview();
                        DescrivtionView.RemoveFromSuperview();
                        preptime.RemoveFromSuperview();
                        preptimelabel.RemoveFromSuperview();
                        Cooktime.RemoveFromSuperview();
                        CooktimeLabel.RemoveFromSuperview();
                        Readyin.RemoveFromSuperview();
                        Readyinlabel.RemoveFromSuperview();
                        difficulty.RemoveFromSuperview();
                        graybox.RemoveFromSuperview();
                        difficultylabel.RemoveFromSuperview();
                        graybox1.RemoveFromSuperview();
                        NutrationalFactsLabel.RemoveFromSuperview();
                        NutrationalFactsLabel.RemoveFromSuperview();
                        foreach (UILabel item in NutrationalFactsList)
                        {
                            item.RemoveFromSuperview();
                        }

                    }
                    if (previousIndex == 1)
                    {
                        foreach (UITextView item in IngrediantList)
                        {
                            item.RemoveFromSuperview();

                        }
                        Cartbutton.RemoveFromSuperview();
                    }

                    previousIndex = 2;

                    foreach (UITextView item in StepList)
                    {
                        scrollView.AddSubview(item);

                    }
                    scrollView.ContentSize = new CGSize(View.Frame.Width, Yforstep + 20);
                }
            };

        }






        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {


            if (segue.Identifier == "CommentSegue")
            {
                var resultview = segue.DestinationViewController as CommentController;
                resultview.isCOmment = true;
                resultview.ViewModel = ViewModel;
                base.PrepareForSegue(segue, sender);

            }
            if (segue.Identifier == "Cartsegue")
            {
                var resultview = segue.DestinationViewController as SelectIngredient;
                resultview.ViewModel = ViewModel;
                base.PrepareForSegue(segue, sender);
            }


            if(segue.Identifier=="ReviewSegue"){
                if (reviewCount > 0)
                {
                    var resultview = segue.DestinationViewController as CommentController;
                    resultview.isCOmment = false;
                    resultview.ViewModel = ViewModel;
                    base.PrepareForSegue(segue, sender);
                }
            }
        }
        public async void getCommentCount()
        { 
            var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info/api/recipe/{0}/reviews?token={1}", ViewModel.Item.stringId, App.currentAccount.JWTToken));
            request.ContentType = "application/JSON";
            request.Method = "GET";


            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string aResponse = "";
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {

                aResponse = sr.ReadToEnd();
                var newitem = JsonConvert.DeserializeObject<List<UserReview>>(aResponse);
                if (newitem == null) { reviewCount = 0; }
                else reviewCount = newitem.Count;
            }

        }
        public async void gettotalRatingt()
        {
            var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info/api/recipe/{0}/totalrating?token={1}", ViewModel.Item.stringId, App.currentAccount.JWTToken));
            request.ContentType = "application/JSON";
            request.Method = "GET";


            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string aResponse = "";
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {

                aResponse = sr.ReadToEnd();
                if (aResponse != null)
                {
                    double ll;
                    if (aResponse != null)
                    {
                        bool asd = double.TryParse(aResponse,out ll);
                        if (asd) { ratingCount = ll; }
                        else { ratingCount = 0; }
                    }
                    else ratingCount = 0;

                }
            }

            }

        }
    }
