using System;
using Foundation;
using UIKit;

namespace IEatHealthy.iOS
{
    public partial class BrowseItemDetailViewController : UIViewController
    {
        public ItemDetailViewModel ViewModel { get; set; }
        public BrowseItemDetailViewController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = ViewModel.Title;
            ItemNameLabel.Text = ViewModel.Item.Text;
            int totaltime = ViewModel.Item.PrepTime + ViewModel.Item.CookTime;
            TotaltimeLabel.Text = totaltime.ToString();
            IngredianPic.Image = ViewModel.Item.picture;
            string ingrediantlistview="";
            if (ViewModel.Item.Ingrediants != null)
            {
                foreach (string item in ViewModel.Item.Ingrediants)
                {
                    ingrediantlistview = ingrediantlistview + item + "\n";
                }
            }
            listIngrediants.Text = ingrediantlistview;


        }
        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            var resultview = segue.DestinationViewController as FullDetailViewController;
            resultview.mm = this.ViewModel.Item;
        }
    }
}
