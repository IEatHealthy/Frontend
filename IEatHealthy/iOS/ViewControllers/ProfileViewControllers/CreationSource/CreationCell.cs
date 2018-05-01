using UIKit;
using Foundation;
using CoreGraphics;

namespace IEatHealthy.iOS
{
    public class CreationCell : UICollectionViewCell
    {
        public static readonly NSString CreationID = new NSString("CreationCell");

        [Export("initWithFrame:")]
        public CreationCell(CGRect frame) : base(frame)
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

        public void UpdateRow(CreationElement element)
        {
            LabelView.Text = element.Title;
            ImageView.Image = element.Image;

            ImageView.Frame = new CGRect(10, 5, 50, 50);
            LabelView.Frame = new CGRect(75, 10, 50, 50);
            LabelView.Font = UIFont.FromName("Helvetica-Bold", 14f);
            LabelView.SizeToFit();
        }
    }
}