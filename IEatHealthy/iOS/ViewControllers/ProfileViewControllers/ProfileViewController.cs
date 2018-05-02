using System;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;

namespace IEatHealthy.iOS
{
    public partial class ProfileViewController : UIViewController
    {
        public ProfileViewController(IntPtr handle) : base(handle)
        {
        }

        public UIImageView BadgeImg { get; set; }

        public static AppDelegate App
        {
            get { return (AppDelegate)UIApplication.SharedApplication.Delegate; }
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.View.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            var statusBarHeight = UIApplication.SharedApplication.StatusBarFrame.Size.Height;

            // Background color for the status bar
            var statusbar = new UIView();
            statusbar.Frame = new CGRect(0, 0, View.Bounds.Size.Width, statusBarHeight);
            statusbar.BackgroundColor = UIColor.White;
            this.View.AddSubview(statusbar);

            // User Details Subview
            var InfoView = new UIView();
            InfoView.Frame = new CGRect(0, statusBarHeight, View.Bounds.Size.Width, 150);
            InfoView.BackgroundColor = UIColor.White;
            this.View.AddSubview(InfoView);

            BadgeImg = new UIImageView();
            SetProfileBadge(BadgeImg);
            InfoView.AddSubview(BadgeImg);        

            var NameLabel = new UILabel();
            NameLabel.Frame = new CGRect(20, 90, 10, 10);
            NameLabel.Text = App.currentAccount.username;
            NameLabel.Font = UIFont.FromName("Helvetica-Bold", 17f);
            NameLabel.SizeToFit();
            InfoView.AddSubview(NameLabel);

            var TitleLabel = new UILabel();
            TitleLabel.Frame = new CGRect(20, 115, 10, 10);
            TitleLabel.Text = App.currentAccount.titleSelected.title;
            TitleLabel.TextColor = UIColor.Gray;
            TitleLabel.Font = UIFont.FromName("Helvetica-BoldOblique", 13f);
            TitleLabel.SizeToFit();
            InfoView.AddSubview(TitleLabel);

            editInfo.Frame = new CGRect(260, 100, 100, 30);
            editInfo.BackgroundColor = UIColor.FromRGB(54, 198, 13);
            editInfo.SetTitleColor(UIColor.White, UIControlState.Normal);
            editInfo.Layer.CornerRadius = 5;
            editInfo.SetTitle("Edit Info", UIControlState.Normal);
            InfoView.AddSubview(editInfo);

            signOut.Frame = new CGRect(140, 100, 100, 30);
            signOut.BackgroundColor = UIColor.FromRGB(37, 153, 254);
            signOut.SetTitleColor(UIColor.White, UIControlState.Normal);
            signOut.Layer.CornerRadius = 5;
            signOut.SetTitle("Sign Out", UIControlState.Normal);
            InfoView.AddSubview(signOut);


            // UI segmented control for info, badge and creation tabs
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

            double ContainerLocation = NavLocation + 45;

            // Collection View for the Info tab
            var InfoCollectionLayout = new UICollectionViewFlowLayout
            {
                SectionInset = new UIEdgeInsets(0, 0, 0, 0),
                MinimumInteritemSpacing = 5,
                MinimumLineSpacing = 5,
                ItemSize = new CGSize(View.Bounds.Size.Width, 60),
                ScrollDirection = UICollectionViewScrollDirection.Vertical
            };

            var infoCollection = new UICollectionView(new CGRect(0, ContainerLocation, View.Bounds.Size.Width, 490), InfoCollectionLayout);
            infoCollection.BackgroundColor = UIColor.White;
            infoCollection.ContentSize = View.Frame.Size;

            var infoCollectionSource = new InfoCollectionSource();


            infoCollection.RegisterClassForCell(typeof(InfoCell), InfoCell.InfoID);
            infoCollection.Source = infoCollectionSource;

            // Collection View for the Badge tab
            var badgeCollectionLayout = new UICollectionViewFlowLayout
            {
                SectionInset = new UIEdgeInsets(0, 0, 0, 0),
                MinimumInteritemSpacing = 5,
                MinimumLineSpacing = 5,
                ItemSize = new CGSize(View.Bounds.Size.Width, 60),
                ScrollDirection = UICollectionViewScrollDirection.Vertical
            };

            var BadgeCollection = new UICollectionView(new CGRect(0, ContainerLocation, View.Bounds.Size.Width, 490), badgeCollectionLayout);
            BadgeCollection.BackgroundColor = UIColor.White;
            BadgeCollection.ContentSize = View.Frame.Size;

            var badgeCollectionSource = new BadgeCollectionSource();

            BadgeCollection.RegisterClassForCell(typeof(BadgeCell), BadgeCell.BadgeID);
            BadgeCollection.Source = badgeCollectionSource;
            addEarnedBadges(badgeCollectionSource);
            this.View.AddSubview(BadgeCollection);

            // Collection View for Creations tab
            var creationCollectionLayout = new UICollectionViewFlowLayout
            {
                SectionInset = new UIEdgeInsets(5, 5, 5, 5),
                MinimumInteritemSpacing = 5,
                MinimumLineSpacing = 5,
                ItemSize = new CGSize(View.Bounds.Size.Width, 100),
                ScrollDirection = UICollectionViewScrollDirection.Vertical
            };

            var creationCollection = new UICollectionView(new CGRect(0, ContainerLocation, View.Bounds.Size.Width, 490), creationCollectionLayout);
            creationCollection.BackgroundColor = UIColor.White;
            creationCollection.ContentSize = View.Frame.Size;

            var creationCollectionSource = new CreationCollectionSource();


            creationCollection.RegisterClassForCell(typeof(CreationCell), CreationCell.CreationID);
            creationCollection.Source = creationCollectionSource;

            int previousindex = 1;
            // Segmented Control for navigation among Info, Badge, and Creation tabs
            segmentControl.ValueChanged += (sender, e) =>
            {
                var index = segmentControl.SelectedSegment;
                switch (index)
                {
                    case 0:
                        if (previousindex == 1)
                        {
                            BadgeCollection.RemoveFromSuperview();
                        }
                        else if (previousindex == 2)
                        {
                            creationCollection.RemoveFromSuperview();
                        }
                        this.View.AddSubview(infoCollection);
                        break;
                    case 1:
                        if (previousindex == 0)
                        {
                            infoCollection.RemoveFromSuperview();
                        }
                        else if (previousindex == 2)
                        {
                            creationCollection.RemoveFromSuperview();
                        }
                        this.View.AddSubview(BadgeCollection);
                        break;
                    case 2:
                        if (previousindex == 0)
                        {
                            infoCollection.RemoveFromSuperview();
                        }
                        else if (previousindex == 1)
                        {
                            BadgeCollection.RemoveFromSuperview();
                        }
                        this.View.AddSubview(creationCollection);
                        break;
                }
            };


            void addEarnedBadges(BadgeCollectionSource badgeCollection)
            {
                foreach (Badge badge in App.currentAccount.badgesEarned)
                {
                    int index = badge.badgeId;
                    BadgeElement badgeEle;
                    switch (index)
                    {
                        case 1:
                            badgeEle = new BadgeElement(UIImage.FromBundle("NewbBadge"), "NewbBadge", "Create an Account");
                            badgeCollection.Rows.Add(badgeEle);
                            break;
                        case 2:
                            badgeEle = new BadgeElement(UIImage.FromBundle("MeatFace"), "Carnivore", "Bookmark 10 Recipes");
                            badgeCollection.Rows.Add(badgeEle);
                            break;
                        case 3:
                            badgeEle = new BadgeElement(UIImage.FromBundle("EggFace"), "Egg Face", "Bookmark 5 Breakfast Recipes");
                            badgeCollection.Rows.Add(badgeEle);
                            break;
                        case 4:
                            badgeEle = new BadgeElement(UIImage.FromBundle("VeggieFace"), "Mother Earth", "Bookmark 10 Salad Recipes");
                            badgeCollection.Rows.Add(badgeEle);
                            break;
                        case 5:
                            badgeEle = new BadgeElement(UIImage.FromBundle("SweetTooth"), "Sweet Tooth", "Bookmark 10 Dessert Recipes");
                            badgeCollection.Rows.Add(badgeEle);
                            break;
                        case 6:
                            badgeEle = new BadgeElement(UIImage.FromBundle("CookieMonster"), "Cookie Monster", "Bookmark 10 Cookie Recipes");
                            badgeCollection.Rows.Add(badgeEle);
                            break;
                        case 7:
                            badgeEle = new BadgeElement(UIImage.FromBundle("SmoothieQueen"), "Smoothie Queen", "Bookmark 5 Smoothie Recipes");
                            badgeCollection.Rows.Add(badgeEle);
                            break;
                        case 8:
                            badgeEle = new BadgeElement(UIImage.FromBundle("SmoothieKing"), "Smoothie King", "Bookmark 10 Smoothie Recipes");
                            badgeCollection.Rows.Add(badgeEle);
                            break;
                        case 9:
                            badgeEle = new BadgeElement(UIImage.FromBundle("BaconFace"), "Keep Calm & Eat Bacon", "Bookmark 10 Breakfast Recipes");
                            badgeCollection.Rows.Add(badgeEle);
                            break;
                        case 10:
                            badgeEle = new BadgeElement(UIImage.FromBundle("FishFace"), "The Fisherman", "Bookmark 10 Fish Recipes");
                            badgeCollection.Rows.Add(badgeEle);
                            break;
                    }
                }
            }

            void SetProfileBadge(UIImageView badgeImg)
            {
                int index = App.currentAccount.badgeSelected.badgeId;
                switch (index)
                {
                    case 1:
                        badgeImg.Image = UIImage.FromBundle("NewbBadge");
                        break;
                    case 2:
                        badgeImg.Image = UIImage.FromBundle("Carnivore");
                        break;
                    case 3:
                        badgeImg.Image = UIImage.FromBundle("EggFace");
                        break;
                    case 4:
                        badgeImg.Image = UIImage.FromBundle("VeggieFace");
                        break;
                    case 5:
                        badgeImg.Image = UIImage.FromBundle("SweetTooth");
                        break;
                    case 6:
                        badgeImg.Image = UIImage.FromBundle("CookieMonster");
                        break;
                    case 7:
                        badgeImg.Image = UIImage.FromBundle("SmoothieQueen");
                        break;
                    case 8:
                        badgeImg.Image = UIImage.FromBundle("SmoothieKing");
                        break;
                    case 9:
                        badgeImg.Image = UIImage.FromBundle("BaconFace");
                        break;
                    case 10:
                        badgeImg.Image = UIImage.FromBundle("FishFace");
                        break;
                }
                badgeImg.Frame = new CGRect(20, 20, 60, 60);
                badgeImg.Layer.BorderColor = UIColor.FromRGB(100, 100, 100).CGColor;
                badgeImg.Layer.BorderWidth = 2;
                badgeImg.Layer.CornerRadius = 5;
                badgeImg.Layer.MasksToBounds = true;
            }
        }
    }
}
