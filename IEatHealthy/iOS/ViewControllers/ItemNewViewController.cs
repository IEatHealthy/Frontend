using System;

using UIKit;

namespace IEatHealthy.iOS
{
    public partial class ItemNewViewController : UIViewController
    {
        partial void PrepValueChange(UITextField sender)
        {
            var preprationtime = preptime.Text;
        }

       
        public ItemsViewModel ViewModel { get; set; }

        public ItemNewViewController(IntPtr handle) : base(handle)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            btnSaveItem.TouchUpInside += (sender, e) =>
            {
                var item = new Item
                {
                    Text = txtTitle.Text,
                    Description = txtDesc.Text,
                };
                ViewModel.AddItemCommand.Execute(item);
                //NavigationController.PopToRootViewController(true);
            };
        }
    }
}
