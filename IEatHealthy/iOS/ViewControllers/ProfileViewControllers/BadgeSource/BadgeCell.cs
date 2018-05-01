using UIKit;
using Foundation;
using CoreGraphics;

namespace IEatHealthy.iOS
{
    public class BadgeCell : UICollectionViewCell
    {
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
            LabelView.Text = element.Title;
            ImageView.Image = element.Image;
            Description.Text = element.Description;

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
            ChangeProfile.TouchUpInside += (object sender, System.EventArgs e) =>
            {

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
