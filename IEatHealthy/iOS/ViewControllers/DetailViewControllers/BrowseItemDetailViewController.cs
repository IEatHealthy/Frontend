using System;
using System.Linq;
using CoreGraphics;
using Foundation;
using UIKit;
using System.Collections.Generic;


namespace IEatHealthy.iOS
{
    public partial class BrowseItemDetailViewController : UIViewController
    {
        public ItemDetailViewModel ViewModel { get; set; }
        public List<UITextView> IngrediantList = new List<UITextView>();
        public List<UITextView> StepList = new List<UITextView>();

        public BrowseItemDetailViewController(IntPtr handle) : base(handle) { }
        public int itemsss = 0;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //   Title = ViewModel.Item.Text;

            scrollView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;

            UILabel recipename = new UILabel(new CGRect(0, 10, View.Frame.Width, 30));
            recipename.Text = ViewModel.Item.Text;
            recipename.TextAlignment = UITextAlignment.Center;
            recipename.Font = UIFont.FromName("Helvetica-Bold", 20f);
            recipename.AutoresizingMask = UIViewAutoresizing.All;
            scrollView.AddSubview(recipename);

            UILabel bylabel = new UILabel(new CGRect(10, 50, 200, 30));
            bylabel.Text = "by " + ViewModel.Item.Author;
            bylabel.Font = UIFont.FromName("Helvetica", 15f);

            scrollView.AddSubview(bylabel);

            UIImageView ratingimg = new UIImageView(new CGRect(10, 90, 80, 20));
            ratingimg.Image = UIImage.FromBundle("RatingIcon");

            UIImageView BookmarkImg = new UIImageView(new CGRect(View.Frame.Width - 60, 50, 20, 30));
            BookmarkImg.Image = UIImage.FromBundle("BookmarkIcon");
            scrollView.AddSubview(BookmarkImg);

            UILabel ratinglabel = new UILabel(new CGRect(10, 114, 100, 15));
            ratinglabel.Text = "  5 of 5";
            scrollView.AddSubviews(ratingimg, ratinglabel);

            UISegmentedControl RecipeControl = new UISegmentedControl(new CGRect(10, 140, 350, 30));
            RecipeControl.InsertSegment("Detail", 0, false);
            RecipeControl.InsertSegment("Ingredients", 1, false);
            RecipeControl.InsertSegment("Preperation steps", 2, false);
            RecipeControl.Layer.BorderColor = (UIColor.White).CGColor;
            RecipeControl.Layer.BorderWidth = 0f;
            RecipeControl.SelectedSegment = 0;

            UIImage pp = new UIImage();
            pp = ViewModel.Item.picture;
            float x = (float)pp.Size.Width;
            float y = (float)pp.Size.Height;
            float ratio = x / y;
            y = (float)((View.Frame.Width - 80) / ratio);



            UIImageView recipeImage = new UIImageView(new CGRect(40, 180, View.Frame.Width - 80, y));
            recipeImage.Image = ViewModel.Item.picture;


            scrollView.AddSubview(recipeImage);
            scrollView.AddSubview(RecipeControl);

            UITextView DescrivtionView = new UITextView(new CGRect(30, recipeImage.Frame.Y + recipeImage.Frame.Height + 10, View.Frame.Width - 60, 40));
            DescrivtionView.Text = ViewModel.Item.BriefDescribtion;
            DescrivtionView.AutoresizingMask = UIViewAutoresizing.All;
            DescrivtionView.Font = UIFont.FromName("Helvetica", 14f);
            DescrivtionView.SizeToFit();
            DescrivtionView.ScrollEnabled = false;
            DescrivtionView.Text = ViewModel.Item.BriefDescribtion;
            scrollView.AddSubview(DescrivtionView);

            UILabel graybox = new UILabel(new CGRect(0, DescrivtionView.Frame.Y + 40, View.Frame.Width, 5));
            graybox.BackgroundColor = UIColor.Gray;
            graybox.Layer.CornerRadius = -10;
            scrollView.AddSubview(graybox);

            UILabel preptimelabel = new UILabel(new CGRect(20, DescrivtionView.Frame.Y + 50, 100, 20));
            preptimelabel.Font = UIFont.FromName("Helvetica", 14f);

            preptimelabel.Text = "Prep Time";
            UILabel preptime = new UILabel(new CGRect(140, DescrivtionView.Frame.Y + 50, 100, 20));
            preptime.Text = ViewModel.Item.PrepTime + " Min";
            preptime.Font = UIFont.FromName("Helvetica", 14f);


            UILabel CooktimeLabel = new UILabel(new CGRect(20, DescrivtionView.Frame.Y + 80, 100, 20));
            CooktimeLabel.Text = "Cook Time";
            CooktimeLabel.Font = UIFont.FromName("Helvetica", 14f);

            UILabel Cooktime = new UILabel(new CGRect(140, DescrivtionView.Frame.Y + 80, 100, 20));
            Cooktime.Text = ViewModel.Item.CookTime + " Min";
            Cooktime.Font = UIFont.FromName("Helvetica", 14f);

            UILabel Readyinlabel = new UILabel(new CGRect(20, DescrivtionView.Frame.Y + 110, 100, 20));
            Readyinlabel.Text = "Ready In";
            Readyinlabel.Font = UIFont.FromName("Helvetica", 14f);

            UILabel Readyin = new UILabel(new CGRect(140, DescrivtionView.Frame.Y + 110, 100, 20));
            Readyin.Text = ViewModel.Item.ReadyTime + " Min";
            Readyin.Font = UIFont.FromName("Helvetica", 14f);




            UILabel difficultylabel = new UILabel(new CGRect(20, Readyin.Frame.Y + 30, 100, 20));
            difficultylabel.Text = "Difficulty ";
            difficultylabel.Font = UIFont.FromName("Helvetica", 14f);

            UILabel difficulty = new UILabel(new CGRect(140, Readyin.Frame.Y + 30, 100, 20));
            difficulty.Text = ViewModel.Item.Difficulty;
            difficulty.Font = UIFont.FromName("Helvetica", 14f);

            UILabel graybox1 = new UILabel(new CGRect(0, difficulty.Frame.Y + 30, View.Frame.Width, 5));
            graybox1.BackgroundColor = UIColor.Gray;
            scrollView.AddSubview(graybox1);

            UILabel NutrationalFactsLabel = new UILabel(new CGRect(20, graybox1.Frame.Y + 30, 300, 30));
            NutrationalFactsLabel.Text = "Nutrition Facts";
            NutrationalFactsLabel.Font = UIFont.FromName("Helvetica-bold", 16f);

            UILabel Label1 = new UILabel(new CGRect(20, graybox1.Frame.Y + 60, 300, 30));
            Label1.Text = "Nutrition Facts will be presented bellow";



            scrollView.AddSubviews(preptime, preptimelabel, Cooktime, CooktimeLabel, Readyin, Readyinlabel, difficulty, difficultylabel, NutrationalFactsLabel, graybox1, Label1);





            scrollView.ContentSize = new CGSize(View.Frame.Width, Label1.Frame.Y);

            int YforIngredient = (int)(recipeImage.Frame.Y + 10);

            var CartButton = new UIButton(UIButtonType.Custom)
            {
                Frame = new CGRect(View.Frame.Width - 45, YforIngredient, 30, 20),
            };
            //CartButton.Layer.BorderWidth = 1f;
            CartButton.SetImage(UIImage.FromBundle("CartTab"), UIControlState.Normal);


            YforIngredient += 30;

            if (ViewModel.Item.Ingrediants != null || ViewModel.Item.Ingrediants.Length != 0)
            {

                foreach (string item in ViewModel.Item.Ingrediants)
                {

                    UITextView label2 = new UITextView(new System.Drawing.RectangleF(20, YforIngredient, 350, 30));
                    //label.Placeholder = " Step " + i.ToString();
                    //  label2.Layer.BorderWidth = 0.1f;
                    label2.Layer.CornerRadius = 8;
                    label2.Font = UIFont.FromName("Helvetica", 14f);

                    label2.ScrollEnabled = false;
                    label2.Editable = false;
                    label2.Text = item;
                    label2.AutoresizingMask = UIViewAutoresizing.All;

                    IngrediantList.Add(label2);
                    YforIngredient += (int)label2.Frame.Height;


                }
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
                        CartButton.RemoveFromSuperview();

                    }
                    if (previousIndex == 2)
                    {
                        foreach (UITextView item in StepList)
                        {
                            item.RemoveFromSuperview();

                        }
                    }
                    scrollView.AddSubviews(graybox, recipeImage, DescrivtionView, preptime, preptimelabel, Cooktime, CooktimeLabel, Readyin, Readyinlabel, difficulty, difficultylabel, graybox1, NutrationalFactsLabel, Label1);
                    scrollView.ContentSize = new CGSize(View.Frame.Width, Label1.Frame.Y);

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
                        Label1.RemoveFromSuperview();


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
                    scrollView.AddSubview(CartButton);
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
                        Label1.RemoveFromSuperview();

                    }
                    if (previousIndex == 1)
                    {
                        foreach (UITextView item in IngrediantList)
                        {
                            item.RemoveFromSuperview();

                        }
                        CartButton.RemoveFromSuperview();
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
            // base.PrepareForSegue(segue, sender);
            // var resultview = segue.DestinationViewController as FullDetailViewController;
            // resultview.mm = this.ViewModel.Item;

            //  var ingrediantView = segue.DestinationViewController as SelectIngredient;
            // ingrediantView.ShoppingListNames = this.ViewModel.Item;

        }
    }
}