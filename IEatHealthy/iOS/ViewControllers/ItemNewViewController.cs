using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
using CoreGraphics;

namespace IEatHealthy.iOS
{
    public partial class ItemNewViewController : UIViewController
    {   
        
        public List<UITextField> IngrediantList = new List<UITextField>();
        public List<UITextView> PreperationStepsList = new List<UITextView>();
        UIImagePickerController picker;
        int textfield=0;
        int textview = 0;
        int ingcount = 1;
        int stepcount = 1;
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
            int YforIngrediant = 318;
            int YforStep = 410;
           int YforInstructionLabel = 380;
            base.ViewDidLoad();
            scrollView.ContentSize = new CGSize(View.Frame.Width, View.Frame.Height);
            scrollView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;


            UITextField label1 = new UITextField(new System.Drawing.RectangleF(20, 318, 250, 30));
            //label.Placeholder = " Step " + i.ToString();
            label1.Layer.BorderWidth = 1f;
            label1.Layer.CornerRadius = 8;
            IngrediantList.Add(label1);
            scrollView.AddSubview(label1);

            //AddingrediantButton.Center=new CGPoint(310,YforIngrediant+5);

            YforIngrediant += 50;
            // YforStep += 50;

            var AddIngrediantButton = new UIButton(UIButtonType.ContactAdd)
            {
                Frame = new CGRect(300,318, 20,20),
               
            };

            var AddStepButton = new UIButton(UIButtonType.ContactAdd)
            {
                Frame = new CGRect(300, YforStep, 20, 20),


            };

            var btnSaveItem = new UIButton(UIButtonType.Custom)
            {
                Frame = new CGRect(40, 480, 150, 30),
                BackgroundColor = UIColor.White,

            };
            AddIngrediantButton.SetTitle("Add Recipe", UIControlState.Normal);
            scrollView.AddSubview(AddIngrediantButton);


            AddIngrediantButton.TouchUpInside += (s, e) =>
            {

                ingcount++;
                UITextField label2 = new UITextField(new System.Drawing.RectangleF(20, YforIngrediant, 250, 30));
                //label.Placeholder = " Step " + i.ToString();
                label2.Layer.BorderWidth = 1f;
                label2.Layer.CornerRadius = 8;
                IngrediantList.Add(label2);
                scrollView.AddSubview(label2);

                AddIngrediantButton.Center = new CGPoint(310, YforIngrediant + 15);
                 foreach (UITextView item in PreperationStepsList)
                 {
                     item.Center = new CGPoint(148, item.Frame.Y + 80);

                 }
                 

                YforIngrediant += 50;
                YforInstructionLabel += 50;
                InstructionLabel.Center = new CGPoint(80, InstructionLabel.Frame.Y+65);
                AddStepButton.Center = new CGPoint(310, AddStepButton.Frame.Y + 65);
                YforStep += 50;
                textfield += 65;
                scrollView.ContentSize = new CGSize(View.Frame.Width, View.Frame.Height +textview+textfield);
                btnSaveItem.Center = new CGPoint(100, btnSaveItem.Frame.Y + 70);
            };


          
            scrollView.AddSubview(AddStepButton);

            UITextView label = new UITextView(new System.Drawing.RectangleF(20, YforStep, 270, 50));
            //label.Placeholder = " Step " + i.ToString();
            label.Layer.BorderWidth = 1f;
            label.Layer.CornerRadius = 8;
            PreperationStepsList.Add(label);
            scrollView.AddSubview(label);

            AddStepButton.Center = new CGPoint(330, YforStep+15);

            AddStepButton.TouchUpInside += (s, e) =>
            {
                stepcount++;
                YforStep += 70;
                UITextView label3 = new UITextView(new System.Drawing.RectangleF(15, YforStep, 270, 50));
                //label.Placeholder = " Step " + i.ToString();
                label3.Layer.BorderWidth = 1f;
                label3.Layer.CornerRadius = 8;
                PreperationStepsList.Add(label3);
                scrollView.AddSubview(label3);

                AddStepButton.Center = new CGPoint(310, AddStepButton.Frame.Y+ 80);
                textview += 80;
                scrollView.ContentSize = new CGSize(View.Frame.Width, View.Frame.Height + textview + textfield);
                btnSaveItem.Center = new CGPoint(100, btnSaveItem.Frame.Y + 85);

            };





            btnSaveItem.SetTitle("Save Recipe", UIControlState.Normal);
            scrollView.AddSubview(btnSaveItem);
            btnSaveItem.SetTitleColor(UIColor.Blue, UIControlState.Normal);
            btnSaveItem.TouchUpInside += (sender, e) =>
            {
               
                if (preptime.Text == null) { preptime.Text = "0"; }
                if (cooktime.Text == null) { cooktime.Text = "0"; }
                var item = new Item
                {
                    Text = RecipeName.Text,
                    PrepTime = Convert.ToInt32(preptime.Text),
                    CookTime = Convert.ToInt32(cooktime.Text),
                    picture = imgView.Image,
                    Ingrediants = convertStep(IngrediantList),
                    steps=convertIng(PreperationStepsList),


                   
                };
                ViewModel.AddItemCommand.Execute(item);
                NavigationController.PopToRootViewController(true);
            };

        }

        string[] convertIng(List<UITextView>name){
            string[] ing=new string[ingcount];
            int i = 0;
            foreach (UITextView item in name)
            {
                ing[i] = item.Text;
                i++;
            }
            return ing;

        }
        string[] convertStep(List<UITextField> name)
        {
            string[] ing = new string[ingcount];
            int i = 0;
            foreach (UITextField item in name)
            {
                ing[i] = item.Text;
                i++;
            }
            return ing;

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