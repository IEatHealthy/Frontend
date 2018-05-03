using System;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace IEatHealthy.iOS
{
    public partial class ProfileViewController : UIViewController
    {
        public ProfileViewController(IntPtr handle) : base(handle)
        {
        }
        public ItemsViewModel ViewModel { get; set; }
        public UIImageView BadgeImg { get; set; }
        public List<Item> creationList { get; set; }
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
            ViewModel = new ItemsViewModel();
            getCreationData();
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
            signOut.TouchUpInside += (sender, e) => {
                App.currentAccount.JWTToken = null;
            };


            // UI segmented control for info, badge and creation tabs
            double NavLocation = statusBarHeight + 150.0;

            var segmentControl = new UISegmentedControl();
            UISegmentedControl.AppearanceWhenContainedIn();
            segmentControl.Frame = new CGRect(0, NavLocation, View.Bounds.Size.Width, 40);
            segmentControl.BackgroundColor = UIColor.White;
            segmentControl.TintColor = UIColor.Clear;

            segmentControl.InsertSegment("Badges", 0, false);
            segmentControl.InsertSegment("Creations", 1, false);
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

            segmentControl.SelectedSegment = 0;

            this.View.AddSubview(segmentControl);

            double ContainerLocation = NavLocation + 45;

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

            //foreach (Item item in creationList)
            //{
            //    ViewModel.Items.Add(item);
            //}

            var creationCollection = new UITableView(new CGRect(0, ContainerLocation, View.Bounds.Size.Width, 490));
            creationCollection.BackgroundColor = UIColor.White;
            creationCollection.ContentSize = View.Frame.Size;
            creationCollection.RowHeight = UITableView.AutomaticDimension;
            creationCollection.EstimatedRowHeight = 200;
            creationCollection.SeparatorColor = UIColor.Red;
            creationCollection.ReloadData();

            var creationCollectionSource = new CreationSource(ViewModel, this);

            creationCollection.Source = creationCollectionSource;

            // Segmented Control for navigation among Badge and Creation tabs
            segmentControl.ValueChanged += (sender, e) =>
            {
                var index = segmentControl.SelectedSegment;
                switch (index)
                {
                    case 0:
                        creationCollection.RemoveFromSuperview();
                        this.View.AddSubview(BadgeCollection);
                        break;
                    case 1:
                        BadgeCollection.RemoveFromSuperview();
                        this.View.AddSubview(creationCollection);
                        break;
                }
            };
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

        void addEarnedBadges(BadgeCollectionSource badgeCollection)
        {
            // under the assumption that the # of titles and badges are the same.
            for (int i = 0; i < App.currentAccount.badgesEarned.Count; i++)
            {
                Badge badgeTemp;
                badgeTemp = App.currentAccount.badgesEarned[i];
                BadgeElement badgeEle = new BadgeElement(badgeTemp);
                badgeCollection.Rows.Add(badgeEle);
            }
        }


        //does not request async. still figuring it out
        public async void getCreationData()
        {
            foreach (string created in App.currentAccount.recipesCreated)
            {
                var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info/api/recipe/id?id={0}&token={1}", created, App.currentAccount.JWTToken));
                request.ContentType = "application/JSON";
                request.Method = "GET";


                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                string aResponse = "";
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {

                    aResponse = sr.ReadToEnd();
                    Item newitem = JsonConvert.DeserializeObject<Item>(aResponse);
                    ViewModel.Items.Add(newitem);
                }
            }
        }
    }
}
