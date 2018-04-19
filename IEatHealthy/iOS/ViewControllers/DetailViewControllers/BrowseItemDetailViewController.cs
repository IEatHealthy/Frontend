using System;
using System.Linq;
using CoreGraphics;
using Foundation;
using UIKit;


namespace IEatHealthy.iOS
{
    public partial class BrowseItemDetailViewController : UIViewController
    {
        public ItemDetailViewModel ViewModel { get; set; }
        public BrowseItemDetailViewController(IntPtr handle) : base(handle) { }
        public int itemsss = 0;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            scrollView.ContentSize = new CGSize(View.Frame.Width, View.Frame.Height*2);
            scrollView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;

            IngredianPic.Image = ViewModel.Item.picture;
            int YforEverything = (int)(IngredianPic.Frame.Height);

            UILabel graybox = new UILabel(new CGRect(0, YforEverything-5, View.Frame.Width, 5));
            graybox.BackgroundColor = UIColor.Gray;
            scrollView.AddSubview(graybox);


            YforEverything += 15;
            PrepTimeLabel.Center = new CGPoint(60, YforEverything);
            CookTimeLabel.Center = new CGPoint(180, YforEverything);
            ReadyInLabel.Center = new CGPoint(300, YforEverything);
            PrepTimeLabel.Text = "PrepTime " + ViewModel.Item.PrepTime.ToString();
            CookTimeLabel.Text = "CookTime " + ViewModel.Item.CookTime.ToString();
            ReadyInLabel.Text = "ReadyIn " + ViewModel.Item.ReadyTime.ToString();

            YforEverything += 20;
            UILabel RecipeDifficulty = new UILabel(new CGRect(10, YforEverything, 120, 20));
            RecipeDifficulty.Text = "Difficulty " + ViewModel.Item.Difficulty;
            scrollView.AddSubview(RecipeDifficulty);


            YforEverything += 30;


            UILabel ServingSizelabel = new UILabel(new CGRect(10, YforEverything, 120, 20));
            ServingSizelabel.Text = "Serving Size " + ViewModel.Item.ServingSize.ToString();
            scrollView.AddSubview(ServingSizelabel);



            YforEverything += 30;
            UILabel graybox4 = new UILabel(new CGRect(0, YforEverything - 5, View.Frame.Width, 2));
            graybox4.BackgroundColor = UIColor.Gray;
            scrollView.AddSubview(graybox);


            UILabel BriefDescrivtion = new UILabel(new CGRect(10, YforEverything, 180, 20));
            BriefDescrivtion.Text = "Brief Describtion";
            scrollView.AddSubview(BriefDescrivtion);

            YforEverything += 30;
            UITextView DescrivtionView = new UITextView(new CGRect(10, YforEverything, View.Frame.Width - 60, 40));
            DescrivtionView.Text = ViewModel.Item.BriefDescribtion;
            DescrivtionView.AutoresizingMask = UIViewAutoresizing.All;
            DescrivtionView.SizeToFit();
            DescrivtionView.ScrollEnabled = false;
            DescrivtionView.Text = ViewModel.Item.BriefDescribtion;
            scrollView.AddSubview(DescrivtionView);

            YforEverything += (int)DescrivtionView.Frame.Height;

            UILabel graybox3 = new UILabel(new CGRect(0, YforEverything - 5, View.Frame.Width, 2));
            graybox3.BackgroundColor = UIColor.Gray;
            scrollView.AddSubview(graybox3);

            UILabel Ingredientlist = new UILabel(new CGRect(10, YforEverything, 180, 20));
            Ingredientlist.Text = "Ingredients ";
            scrollView.AddSubview(Ingredientlist);

            var CartButton = new UIButton(UIButtonType.Custom)
            {
                Frame = new CGRect(View.Frame.Width-45, YforEverything+5, 30, 20),
            };
            //CartButton.Layer.BorderWidth = 1f;
            CartButton.SetImage(UIImage.FromBundle("CartTab"), UIControlState.Normal);
            scrollView.AddSubview(CartButton);




            YforEverything += 30;

            if (ViewModel.Item.Ingrediants != null || ViewModel.Item.Ingrediants.Length != 0)
            {

                foreach (string item in ViewModel.Item.Ingrediants)
                {

                    UITextView label2 = new UITextView(new System.Drawing.RectangleF(20, YforEverything, 250, 20));
                    //label.Placeholder = " Step " + i.ToString();
                    //  label2.Layer.BorderWidth = 0.1f;
                    label2.Layer.CornerRadius = 8;
                    label2.Editable = false;
                    label2.Text = item;
                    scrollView.AddSubview(label2);
                    YforEverything += 30;


                }
            }
            UILabel graybox2 = new UILabel(new CGRect(0, YforEverything - 5, View.Frame.Width, 2));
            graybox2.BackgroundColor = UIColor.Gray;
            scrollView.AddSubview(graybox2);

            UILabel StepList = new UILabel(new CGRect(10, YforEverything, 180, 20));
            StepList.Text = "Preperation Steps ";
            scrollView.AddSubview(StepList);

            YforEverything += 30;
           

            {
                foreach (string item in ViewModel.Item.steps)
                {
                    UITextView label2 = new UITextView(new System.Drawing.RectangleF(20, YforEverything, 250, 1));
                    //label.Placeholder = " Step " + i.ToString();
                    //   label2.Layer.BorderWidth = 0.1f;
                    label2.Layer.CornerRadius = 8;
                    label2.Text = item;
                    label2.AutoresizingMask = UIViewAutoresizing.All;
                    label2.SizeToFit();
                    label2.ScrollEnabled = false;
                    label2.Editable = false;
                    scrollView.AddSubview(label2);
                    YforEverything += (int)label2.Frame.Height;

                }
            }






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