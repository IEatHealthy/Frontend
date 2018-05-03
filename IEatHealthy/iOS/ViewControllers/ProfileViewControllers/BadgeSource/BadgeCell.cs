using UIKit;
using Foundation;
using CoreGraphics;

namespace IEatHealthy.iOS
{
    public class BadgeCell : UICollectionViewCell
    {
        public static AppDelegate App
        {
            get { return (AppDelegate)UIApplication.SharedApplication.Delegate; }
        }

        public static readonly NSString BadgeID = new NSString("BadgeCell");

        [Export("initWithFrame:")]
        public BadgeCell(CGRect frame) : base(frame)
        {
            ImageView = new UIImageView();
            ImageView.ContentMode = UIViewContentMode.ScaleToFill;

            LabelView = new UILabel();

            ChangeProfile = new UIButton();

            Description = new UILabel();

            setupViews();
            ContentView.BackgroundColor = UIColor.White;
        }

        public UIImageView ImageView { get; private set; }

        public UILabel LabelView { get; private set; }

        public UIButton ChangeProfile { get; private set; }

        public UILabel Description { get; private set; }

        public void setupViews()
        {
            ContentView.AddSubview(ImageView);
            ContentView.AddSubview(LabelView);
            ContentView.AddSubview(ChangeProfile);
            ContentView.AddSubview(Description);
        }

        public void UpdateRow(BadgeElement element)
        {
            int index = element.CurrentBadge.badgeId;
            switch (index)
            {
                case 1:
                    ImageView.Image = UIImage.FromBundle("NewbBadge");
                    LabelView.Text = "The Newbie";
                    break;
                case 2:
                    ImageView.Image = UIImage.FromBundle("MeatFace");
                    LabelView.Text = "Carnivore";
                    break;
                case 3:
                    ImageView.Image = UIImage.FromBundle("EggFace");
                    LabelView.Text = "Egg Face";
                    break;
                case 4:
                    ImageView.Image = UIImage.FromBundle("VeggieFace");
                    LabelView.Text = "Mother Earth";
                    break;
                case 5:
                    ImageView.Image = UIImage.FromBundle("SweetTooth");
                    LabelView.Text = "Sweet Tooth";
                    break;
                case 6:
                    ImageView.Image = UIImage.FromBundle("CookieMonster");
                    LabelView.Text = "Cookie Monster";
                    break;
                case 7:
                    ImageView.Image = UIImage.FromBundle("SmoothieQueen");
                    LabelView.Text = "Smoothie Queen";
                    break;
                case 8:
                    ImageView.Image = UIImage.FromBundle("SmoothieKing");
                    LabelView.Text = "Smoothie King";
                    break;
                case 9:
                    ImageView.Image = UIImage.FromBundle("BaconFace");
                    LabelView.Text = "Keep Calm & Eat Bacon";
                    break;
                case 10:
                    ImageView.Image = UIImage.FromBundle("FishFace");
                    LabelView.Text = "The Fisherman";
                    break;
            }

            Description.Text = element.CurrentBadge.description;

            ChangeProfile.Frame = new CGRect(305, 15, 50, 50);
            var normal = new NSAttributedString(
                "Change",
                font: UIFont.FromName("Helvetica-Bold", 11.0f),
                foregroundColor: UIColor.Black,
                strokeWidth: 0
            );
            var selected = new NSAttributedString(
                "Change",
                font: UIFont.FromName("Helvetica-Bold", 11.0f),
                foregroundColor: UIColor.Red,
                strokeWidth: 0
            );
            ChangeProfile.SetAttributedTitle(normal, UIControlState.Normal);
            ChangeProfile.SetAttributedTitle(selected, UIControlState.Selected);
            ChangeProfile.BackgroundColor = UIColor.White;
            ChangeProfile.SizeToFit();

            ChangeProfile.TouchUpInside += (s, e) =>
            {
                if (App.currentAccount.badgeSelected.badgeId == element.CurrentBadge.badgeId)
                {
                    return;
                }
                else
                {
                    App.currentAccount.badgeSelected = element.CurrentBadge;
                }
            };

            ImageView.Frame = new CGRect(10, 5, 50, 50);
            LabelView.Frame = new CGRect(75, 15, 50, 50);
            LabelView.Font = UIFont.FromName("Helvetica-Bold", 14f);
            LabelView.SizeToFit();
            Description.Frame = new CGRect(75, 35, 50, 50);
            Description.Font = UIFont.FromName("Helvetica", 12);
            Description.SizeToFit();
        }
    }
}
