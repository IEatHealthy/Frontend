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

            setupViews();
            ContentView.BackgroundColor = UIColor.White;
        }

        public UIImageView ImageView { get; private set; }

        public UILabel LabelView { get; private set; }

        public void setupViews()
        {
            ContentView.AddSubview(ImageView);
            ContentView.AddSubview(LabelView);


        }

        public void UpdateRow(BadgeElement element)
        {
            LabelView.Text = element.Title;
            ImageView.Image = element.Image;

            ImageView.Frame = new CGRect(5, 5, 60, 60);
            LabelView.Frame = new CGRect(70, 0, 50, 50);
        }
    }
}