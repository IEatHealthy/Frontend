using System;
//using System.IdentityModel.Tokens.Jwt;
using Foundation;  
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
           
namespace IEatHealthy.iOS
{
    public partial class moreviewcontroller : UIViewController
    {
        public static AppDelegate App
        {
            get { return (AppDelegate)UIApplication.SharedApplication.Delegate; }
        }

        public moreviewcontroller(IntPtr handle) : base(handle)
        {
            
        }
        /*   partial void SignOutButton_TouchUpInside(UIButton sender)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadToken(App.currentAccount.JWTToken) as JwtSecurityToken;

        }
        */
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();



            this.View.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            var statusBarHeight = UIApplication.SharedApplication.StatusBarFrame.Size.Height;

            var statusbar = new UIView();
            statusbar.Frame = new CGRect(0, 0, View.Bounds.Size.Width, statusBarHeight);
            statusbar.BackgroundColor = UIColor.White;
            this.View.AddSubview(statusbar);

            // User Details
            var InfoView = new UIView();
            InfoView.Frame = new CGRect(0, statusBarHeight, View.Bounds.Size.Width, 150);
            InfoView.BackgroundColor = UIColor.White;
            this.View.AddSubview(InfoView);

            var BadgeImg = new UIImageView();
            BadgeImg.Frame = new CGRect(20, 20, 60, 60);
            BadgeImg.Image = UIImage.FromBundle("NewbBadge");
            BadgeImg.Layer.BorderColor = UIColor.FromRGB(100, 100, 100).CGColor;
            BadgeImg.Layer.BorderWidth = 2;
            BadgeImg.Layer.CornerRadius = 5;
            BadgeImg.Layer.MasksToBounds = true;
            InfoView.AddSubview(BadgeImg);

            var NameLabel = new UILabel();
            NameLabel.Frame = new CGRect(20, 90, 10, 10);
            NameLabel.Text = "chochris109";
            NameLabel.Font = UIFont.FromName("Helvetica-Bold", 17f);
            NameLabel.SizeToFit();
            InfoView.AddSubview(NameLabel);

            var TitleLabel = new UILabel();
            TitleLabel.Frame = new CGRect(20, 115, 10, 10);
            TitleLabel.Text = "Master Chef";
            TitleLabel.TextColor = UIColor.Gray;
            TitleLabel.Font = UIFont.FromName("Helvetica-BoldOblique", 13f);
            TitleLabel.SizeToFit();
            InfoView.AddSubview(TitleLabel);

            // UI segmented control
            double NavLocation = statusBarHeight + 150.0;

            var segmentControl = new UISegmentedControl();
            UISegmentedControl.AppearanceWhenContainedIn();
            segmentControl.Frame = new CGRect(0, NavLocation, View.Bounds.Size.Width, 40);
            segmentControl.BackgroundColor = UIColor.White;
            segmentControl.TintColor = UIColor.Clear;

            segmentControl.InsertSegment("Info", 0, false);
            segmentControl.InsertSegment("Badges", 1, false);
            segmentControl.InsertSegment("Creations", 2, false);
            segmentControl.SetTitleTextAttributes(new UITextAttributes()
            {
                TextColor = UIColor.Black,
                Font = UIFont.FromName("Helvetica-Bold", 14f),
                TextShadowColor = UIColor.Clear
            }, UIControlState.Normal);

            segmentControl.SetTitleTextAttributes(new UITextAttributes()
            {
                TextColor = UIColor.Red,
                Font = UIFont.FromName("Helvetica-Bold", 14f),
                TextShadowColor = UIColor.Clear
            }, UIControlState.Selected);

            segmentControl.SelectedSegment = 1;

            this.View.AddSubview(segmentControl);

            double ContainerLocation = NavLocation + 50;
            var layout = new UICollectionViewLayout();


            // Collection View for the Badges
            var BadgeCollection = new UICollectionView(new CGRect(0, ContainerLocation, View.Bounds.Size.Width, 100), layout);

            this.View.AddSubview(BadgeCollection);

            // Collection View for the Recipe Collections
            var CreationCollection = new UICollectionView(new CGRect(0, ContainerLocation, View.Bounds.Size.Width, 100), layout);

            // Collection View for the Profile Info
            var ProfileCollection = new UICollectionView(new CGRect(0, ContainerLocation, View.Bounds.Size.Width, 100), layout);

            segmentControl.ValueChanged += (sender, e) =>
            {
                var index = segmentControl.SelectedSegment;

                switch (segmentControl.SelectedSegment)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                }

            };

        }
       
    }
}