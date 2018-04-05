using System;
using Foundation;
using UIKit;
using System.Collections.Generic;

namespace IEatHealthy.iOS
{
    public partial class ItemNewViewController : UIViewController
    {
        UIImagePickerController picker;
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
                string []names = txtDesc.Text.Split(',');
                if (preptime.Text == null) { preptime.Text = "0"; }
                if (cooktime.Text == null) { cooktime.Text = "0"; }
                var item = new Item
                {
                    Text = txtTitle.Text,
                    Description = txtDesc.Text,
                    PrepTime = Convert.ToInt32(preptime.Text),
                    CookTime = Convert.ToInt32(cooktime.Text),
                    picture = imgView.Image,
                    Ingrediants = names,


                   
                };
                ViewModel.AddItemCommand.Execute(item);
                NavigationController.PopToRootViewController(true);
            };

        }

        
        partial void BtnPick_TouchUpInside(UIButton sender)
        {
            picker = new UIImagePickerController();
            picker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
            picker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);
            picker.FinishedPickingMedia += Finished;
            picker.Canceled += Canceled;
            PresentViewController(picker, animated: true, completionHandler: null);
        }
        public void Finished(object sender, UIImagePickerMediaPickedEventArgs e)
        {
            bool isImage = false;
            switch (e.Info[UIImagePickerController.MediaType].ToString())
            {
                case "public.image":
                    isImage = true;
                    break;
                case "public.video":
                    break;
            }
            NSUrl referenceURL = e.Info[new NSString("UIImagePickerControllerReferenceUrl")] as NSUrl;
            if (referenceURL != null) Console.WriteLine("Url:" + referenceURL.ToString());
            if (isImage)
            {
                UIImage originalImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;
                if (originalImage != null)
                {
                    imgView.Image = originalImage;
                }
            }
            else
            {
                NSUrl mediaURL = e.Info[UIImagePickerController.MediaURL] as NSUrl;
                if (mediaURL != null)
                {
                    Console.WriteLine(mediaURL.ToString());
                }
            }
            picker.DismissModalViewController(true);
        }
        void Canceled(object sender, EventArgs e)
        {
            picker.DismissModalViewController(true);
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.  
        }
		public override void ViewDidLayoutSubviews()
		{
            base.ViewDidLayoutSubviews();
  
		}
	}
}