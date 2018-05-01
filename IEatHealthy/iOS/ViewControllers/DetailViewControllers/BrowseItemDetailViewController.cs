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
        public List<UILabel> NutrationalFactsList = new List<UILabel>();

        public BrowseItemDetailViewController(IntPtr handle) : base(handle) { }
        public int itemsss = 0;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //   Title = ViewModel.Item.Text;

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

            UIImageView ratingimg = new UIImageView(new CGRect(10, 90, 80, 20));
            ratingimg.Image = UIImage.FromBundle("RatingIcon");


            ReviewButton.Frame = new CGRect(View.Frame.Width - 160, 90, 150, 20);

            ReviewButton.Font = UIFont.FromName("Helvetica", 15f);
            ReviewButton.SetTitle("5 reviews", UIControlState.Normal);
            ReviewButton.SetTitleColor(UIColor.FromRGB(66, 134, 244), UIControlState.Normal);
            scrollView.AddSubview(ReviewButton);

            CommentButton.Frame = new CGRect(View.Frame.Width - 160, 110, 150, 20);
            CommentButton.Font = UIFont.FromName("Helvetica", 15f);
            CommentButton.SetTitle("Rate/Comment", UIControlState.Normal);
            CommentButton.SetTitleColor(UIColor.FromRGB(66, 134, 244), UIControlState.Normal);
            scrollView.AddSubview(CommentButton);


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
          //  pp = ViewModel.Item.picture;
            float x = (float)pp.Size.Width;
            float y = (float)pp.Size.Height;
            float ratio = x / y;
            y = (float)((View.Frame.Width - 80) / ratio);



            UIImageView recipeImage = new UIImageView(new CGRect(40, 180, View.Frame.Width - 80, 100));
           // recipeImage.Image = ViewModel.Item.picture;


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




            UILabel difficultylabel = new UILabel(new CGRect(20, Readyin.Frame.Y + 20, 100, 20));
            difficultylabel.Text = "Difficulty ";
            difficultylabel.Font = UIFont.FromName("Helvetica", 14f);

            UILabel difficulty = new UILabel(new CGRect(140, Readyin.Frame.Y + 20, 100, 20));
            difficulty.Text = ViewModel.Item.difficulty.ToString();
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
            CalorieLabel.Text = "Calories 200";//+ViewModel.Item.calorieCount;
            CalorieLabel.Font = UIFont.FromName("Helvetica", 15f);
            NutrationalFactsList.Add(CalorieLabel);

            UILabel graybox13 = new UILabel(new CGRect(0, CalorieLabel.Frame.Y + 30, View.Frame.Width, 4));
            graybox13.BackgroundColor = UIColor.Gray;
            NutrationalFactsList.Add(graybox13);


            UILabel DailyValue = new UILabel(new CGRect(View.Frame.Width - 170, graybox13.Frame.Y + 4, 150, 30));
            DailyValue.Text = "% Daily Value  ";//+ViewModel.Item.calorieCount;
            DailyValue.Font = UIFont.FromName("Helvetica", 15f);
            DailyValue.TextAlignment = UITextAlignment.Right;
            NutrationalFactsList.Add(DailyValue);

            UILabel graybox14 = new UILabel(new CGRect(0, DailyValue.Frame.Y + 30, View.Frame.Width, 2));
            graybox14.BackgroundColor = UIColor.Gray;
            NutrationalFactsList.Add(graybox14);

            UILabel Fatlabel = new UILabel(new CGRect(20, graybox14.Frame.Y + 4, 300, 20));
            Fatlabel.Text = "Total Fat  0g";//+ViewModel.Item.calorieCount;
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
            satFatlabel.Text = "Saturated Fat  0g";//+ViewModel.Item.calorieCount;
            satFatlabel.Font = UIFont.FromName("Helvetica", 15f);
            NutrationalFactsList.Add(satFatlabel);

            UILabel graybox16 = new UILabel(new CGRect(0, satFatlabel.Frame.Y + 20, View.Frame.Width, 2));
            graybox16.BackgroundColor = UIColor.Gray;
            NutrationalFactsList.Add(graybox16);

            UILabel Transfat = new UILabel(new CGRect(40, graybox16.Frame.Y + 4, 300, 20));
            Transfat.Text = "Trans Fat  0g";//+ViewModel.Item.calorieCount;
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
            cholesLabel.Text = "Cholesterol  0mg";//+ViewModel.Item.calorieCount;
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
            SodiiumLabel.Text = "Sodium  0mg";//+ViewModel.Item.calorieCount;
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
            Carblabel.Text = "Total Carbohydrate  0g";//+ViewModel.Item.calorieCount;
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

           /*
            foreach (IngredientItem item in ViewModel.Item.ingredients)
                {

                    UITextView label2 = new UITextView(new System.Drawing.RectangleF(20, YforIngredient, 350, 30));
                    //label.Placeholder = " Step " + i.ToString();
                    //  label2.Layer.BorderWidth = 0.1f;
                    label2.Layer.CornerRadius = 8;
                    label2.Font = UIFont.FromName("Helvetica", 14f);

                    label2.ScrollEnabled = false;
                    label2.Editable = false;
                    label2.Text = item.ingredientId;
                    label2.AutoresizingMask = UIViewAutoresizing.All;

                    IngrediantList.Add(label2);
                    YforIngredient += (int)label2.Frame.Height;


                }
                */


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
                base.PrepareForSegue(segue, sender);

            }
            if (segue.Identifier == "Cartsegue")
            {
                var resultview = segue.DestinationViewController as SelectIngredient;
                resultview.ViewModel = ViewModel;
                base.PrepareForSegue(segue, sender);
            }


            if(segue.Identifier=="ReviewSegue"){
                var resultview = segue.DestinationViewController as CommentController;
                resultview.isCOmment = false;
                base.PrepareForSegue(segue, sender);

            }

           
           

        }
    }
}