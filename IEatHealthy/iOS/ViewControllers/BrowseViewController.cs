using System;
using System.Collections.Specialized;
using Foundation;
using UIKit;
using CoreGraphics;
using System.Drawing;

namespace IEatHealthy.iOS
{
    public partial class BrowseViewController : UITableViewController
    {
        UIRefreshControl refreshControl;

        public ItemsViewModel ViewModel { get; set; }

        public BrowseViewController(IntPtr handle) : base(handle)
        {
        }



        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            RecipeTableView.RowHeight = 60;
            RecipeTableView.ReloadData();

            ViewModel = new ItemsViewModel();

            NavBar();
            // Setup UITableView.
            refreshControl = new UIRefreshControl();
            refreshControl.ValueChanged += RefreshControl_ValueChanged;
            TableView.Add(refreshControl);
            TableView.Source = new ItemsDataSource(ViewModel);

            ViewModel.PropertyChanged += IsBusy_PropertyChanged;
            ViewModel.Items.CollectionChanged += Items_CollectionChanged;
            RecipeTableView.RowHeight = UITableView.AutomaticDimension;
            RecipeTableView.EstimatedRowHeight = 100;
            RecipeTableView.ReloadData();
        }


        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            if (ViewModel.Items.Count == 0)
                ViewModel.LoadItemsCommand.Execute(null);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "NavigateToItemDetailSegue")
            {
                var controller = segue.DestinationViewController as BrowseItemDetailViewController;
                var indexPath = TableView.IndexPathForCell(sender as UITableViewCell);
                var item = ViewModel.Items[indexPath.Row];

                controller.ViewModel = new ItemDetailViewModel(item);
            }
            else
            {
                var controller = segue.DestinationViewController as ItemNewViewController;
                controller.ViewModel = ViewModel;
            }
        }

        void NavBar() {
            var navBar = NavigationController.NavigationBar;
            navBar.TintColor = UIColor.Red;
            // Adds logo on navigation bar
            var imageView = new UIImageView(UIImage.FromBundle("newlogo"));
            imageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            var titleView = new UIView(new CGRect(0, 0, imageView.Image.CGImage.Width/2.5, imageView.Image.CGImage.Height/2.5));
            imageView.Frame = titleView.Bounds;
            titleView.AddSubview(imageView);
            NavigationItem.TitleView = titleView;

            // Adds search bar to navigation bar
            var search = new UISearchController(searchResultsController: null)
            {
                HidesNavigationBarDuringPresentation = true,
                DimsBackgroundDuringPresentation = true
            };
            search.SearchBar.Placeholder = "Search for a Recipe";
            NavigationItem.SearchController = search;
            NavigationItem.HidesSearchBarWhenScrolling = false;
        }

        void RefreshControl_ValueChanged(object sender, EventArgs e)
        {
            if (!ViewModel.IsBusy && refreshControl.Refreshing)
                ViewModel.LoadItemsCommand.Execute(null);
        }

        void IsBusy_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var propertyName = e.PropertyName;
            switch (propertyName)
            {
                case nameof(ViewModel.IsBusy):
                    {
                        InvokeOnMainThread(() =>
                        {
                            if (ViewModel.IsBusy && !refreshControl.Refreshing)
                                refreshControl.BeginRefreshing();
                            else if (!ViewModel.IsBusy)
                                refreshControl.EndRefreshing();
                        });
                    }
                    break;
            }
        }

        void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            InvokeOnMainThread(() => TableView.ReloadData());
        }
    }

    class ItemsDataSource : UITableViewSource
    {
        static readonly NSString CELL_IDENTIFIER = new NSString("ITEM_CELL");

        ItemsViewModel viewModel;

        public ItemsDataSource(ItemsViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override nint RowsInSection(UITableView tableview, nint section) => viewModel.Items.Count;
        public override nint NumberOfSections(UITableView tableView) => 1;

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UIImage ResizeImage(UIImage sourceImage, float width, float height)
            {   
                UIGraphics.BeginImageContext(new SizeF(width, height));
                sourceImage.Draw(new RectangleF(0, 0, width, height));
                var resultImage = UIGraphics.GetImageFromCurrentImageContext();
                UIGraphics.EndImageContext();
                return resultImage;
            }


            var cell = tableView.DequeueReusableCell(CELL_IDENTIFIER, indexPath);

            var item = viewModel.Items[indexPath.Row];
            cell.TextLabel.Text = item.name;
            cell.DetailTextLabel.Text = item.description;
            cell.LayoutMargins = UIEdgeInsets.Zero;
         //   var imageBytes = Convert.FromBase64String()
         //   var imagedata = NSData.FromArray(imageBytes);
         //   var uiimage = UIImage.LoadFromData(imagedata);
         //   var image = ResizeImage(uiimage, 45, 35);
         //    cell.ImageView.Image = image;




            return cell;
        }
    }
}
