using Foundation;
using System;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Drawing;

namespace IEatHealthy.iOS
{
    public partial class RecipesViewController : UIViewController
    {
        public static AppDelegate App
        {
            get { return (AppDelegate)UIApplication.SharedApplication.Delegate; }
        }

        public RecipesViewController(IntPtr handle) : base(handle)
        {
        }

        public List<string> deletedBookmarks { get; set; }
        public List<Item> bookmarkedList { get; set; }
        public ItemsViewModel ViewModel { get; set; }

        public override void ViewWillAppear(bool animated)
        {
            Title = "Bookmarks";
            ViewModel = new ItemsViewModel();

            foreach (string item in App.currentAccount.bookmarkedRecipes)
            {
                var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info/api/recipe/id?id={0}&token={1}", item, App.currentAccount.JWTToken));
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

            List<Item> items = new List<Item>();

            var creationCollection = new UITableView(new CGRect(0, 50, View.Bounds.Size.Width, 700));
            creationCollection.BackgroundColor = UIColor.White;
            creationCollection.ContentSize = View.Frame.Size;
            creationCollection.RowHeight = UITableView.AutomaticDimension;
            creationCollection.EstimatedRowHeight = 100;
            View.AddSubview(creationCollection);

            var creationCollectionSource = new bookmarkSource(ViewModel, this, deletedBookmarks);

            creationCollection.Source = creationCollectionSource;
            creationCollection.ReloadData();

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }
    }
    class bookmarkSource : UITableViewSource
    {
        public static AppDelegate App
        {
            get { return (AppDelegate)UIApplication.SharedApplication.Delegate; }
        }
        static readonly NSString CELL_IDENTIFIER = new NSString("ITEM_CELL");

        public ItemsViewModel viewModel { get; set; }
        UIViewController owner { get; set; }
        public List<string> deletedBookmarks { get; set; }

        public bookmarkSource(ItemsViewModel ViewModel, UIViewController previous, List<string> deletedbookmarks)
        {
            viewModel = ViewModel;
            owner = previous;
            if (deletedbookmarks != null)
            {
                this.deletedBookmarks = deletedbookmarks;
            }
        }

        public override nint RowsInSection(UITableView tableview, nint section) => viewModel.Items.Count;
        public override nint NumberOfSections(UITableView tableView) => 1;

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {

            UITableViewCell cell = tableView.DequeueReusableCell(CELL_IDENTIFIER);
            if (cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Default, CELL_IDENTIFIER);

            UIImage ResizeImage(UIImage sourceImage, float width, float height)
            {
                UIGraphics.BeginImageContext(new SizeF(width, height));
                sourceImage.Draw(new RectangleF(0, 0, width, height));
                var resultImage = UIGraphics.GetImageFromCurrentImageContext();
                UIGraphics.EndImageContext();
                return resultImage;
            }

            var item = viewModel.Items[indexPath.Row];
            cell.TextLabel.Text = item.name;
            cell.LayoutMargins = UIEdgeInsets.Zero;

            var imageBytes = Convert.FromBase64String(item.foodImage.data);
            var imagedata = NSData.FromArray(imageBytes);
            var uiimage = UIImage.LoadFromData(imagedata);
            var image = ResizeImage(uiimage, 45, 35);
            cell.ImageView.Image = image;

            return cell;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var item = viewModel.Items[indexPath.Row];
            tableView.DeselectRow(indexPath, true);
            var StoryBoard = UIStoryboard.FromName("Main", null);
            var controller = StoryBoard.InstantiateViewController("BrowseItemDetailViewController") as BrowseItemDetailViewController;
            controller.ViewModel = new ItemDetailViewModel(item);
            var navController = new UINavigationController(controller);
            var backButton = new UIBarButtonItem();
            backButton.Title = "Back";
            backButton.Style = UIBarButtonItemStyle.Plain;
            backButton.TintColor = UIColor.Red;
            backButton.Clicked += (sender, e) =>
            {
                owner.DismissViewController(true, null);
            };
            controller.NavigationItem.LeftBarButtonItem = backButton;
            owner.PresentViewController(navController, true, null);
        }
        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, Foundation.NSIndexPath indexPath)
        {
            switch (editingStyle)
            {
                case UITableViewCellEditingStyle.Delete:
                    var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info/api/recipe/bookmark?recipeId={0}&email={1}&token={2}", App.currentAccount.bookmarkedRecipes[indexPath.Row], App.currentAccount.email, App.currentAccount.JWTToken));
                    request.ContentType = "application/JSON";
                    request.Method = "DELETE";
                    try
                    {

                        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                        using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                        {

                            viewModel.Items.RemoveAt(indexPath.Row);
                            tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
                            tableView.ReloadData();

                        }
                    }
                    catch
                    {

                    }

                    break;
                case UITableViewCellEditingStyle.None:
                    break;
            }
        }

    }
}
