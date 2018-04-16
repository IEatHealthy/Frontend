using System;
using Foundation;
using UIKit;

namespace IEatHealthy.iOS
{
    public partial class BrowseItemDetailViewController : UIViewController
    {
        public ItemDetailViewModel ViewModel { get; set; }
        public BrowseItemDetailViewController(IntPtr handle) : base(handle) { }
        public int itemsss = 0;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = ViewModel.Title;
            Brieflabel.Text = ViewModel.Item.BriefDescribtion;
            ServingSizeLabel.Text = ViewModel.Item.ServingSize.ToString();
            ItemNameLabel.Text = ViewModel.Item.Text;
            DifficultyLabel.Text = ViewModel.Item.Difficulty;
            ReadyInLabel.Text = ViewModel.Item.ReadyTime.ToString();
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
           // base.PrepareForSegue(segue, sender);
           // var resultview = segue.DestinationViewController as FullDetailViewController;
           // resultview.mm = this.ViewModel.Item;

          //  var ingrediantView = segue.DestinationViewController as SelectIngredient;
           // ingrediantView.ShoppingListNames = this.ViewModel.Item;

        }
    }
}
