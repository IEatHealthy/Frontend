using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using System.Drawing;

namespace IEatHealthy.iOS
{
    class CreationSource : UITableViewSource
    {
        static readonly NSString CELL_IDENTIFIER = new NSString("ITEM_CELL");

        UIViewController owner;
        public ItemsViewModel ViewModel { get; set; }

        public CreationSource(ItemsViewModel createdRecipes, UIViewController owner)
        {
            ViewModel = createdRecipes;
            this.owner = owner;
        }

        public override nint RowsInSection(UITableView tableview, nint section) => ViewModel.Items.Count;
        public override nint NumberOfSections(UITableView tableView) => 1;

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CELL_IDENTIFIER);

            if (cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Default, CELL_IDENTIFIER);

            //UIImage ResizeImage(UIImage sourceImage, float width, float height)
            //{
            //    UIGraphics.BeginImageContext(new SizeF(width, height));
            //    sourceImage.Draw(new RectangleF(0, 0, width, height));
            //    var resultImage = UIGraphics.GetImageFromCurrentImageContext();
            //    UIGraphics.EndImageContext();
            //    return resultImage;
            //}

            var item = ViewModel.Items[indexPath.Row];
            cell.TextLabel.Text = item.name;
            cell.LayoutMargins = UIEdgeInsets.Zero;

            //var imageBytes = Convert.FromBase64String(item.foodImage.data);
            //var imagedata = NSData.FromArray(imageBytes);
            //var uiimage = UIImage.LoadFromData(imagedata);
            //var image = ResizeImage(uiimage, 45, 35);
            //cell.ImageView.Image = image;

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //            let backButton = UIBarButtonItem(title: "Back", style: UIBarButtonItemStyle.Plain, target: self, action: "goBack")
            //   navigationItem.leftBarButtonItem = backButton

            //}

            //func goBack()
            //{
            //    dismissViewControllerAnimated(true, completion: nil)
            //}
            var item = ViewModel.Items[indexPath.Row];
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

    }
}
