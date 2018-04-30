using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
using CoreGraphics;
using System.Drawing;

namespace IEatHealthy.iOS
{
    public partial class ItemNewViewController : UIViewController
    {   
        
        public List<UITextField> IngrediantList = new List<UITextField>();
        public List<UITextView> PreperationStepsList = new List<UITextView>();
        public List<UITextField> SpecialTools = new List<UITextField>();

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
            View.BackgroundColor = UIColor.FromRGB(229, 231, 232);

            Title = "New Recipe";
            string RecipeDifficulty="intermediate";

            var easy = new UIButton(UIButtonType.Custom)
            {
                Frame = new CGRect(20, DifficultyLabel.Frame.Y+30, 70, 20),

            };
            var Intermediate = new UIButton(UIButtonType.Custom)
            {
                Frame = new CGRect(100, DifficultyLabel.Frame.Y + 30, 140, 20),

            };
            var Hard = new UIButton(UIButtonType.Custom)
            {
                Frame = new CGRect(260, DifficultyLabel.Frame.Y + 30, 70, 20),

            };


            Hard.SetTitleColor(UIColor.Black, UIControlState.Normal);
            Hard.SetTitle("Hard", UIControlState.Normal);
            Hard.Layer.BorderWidth = 0.2f;
            Hard.Layer.CornerRadius = 5;
            scrollView.AddSubview(Hard);

            Intermediate.SetTitle("Intermediate", UIControlState.Normal);
            Intermediate.SetTitleColor(UIColor.Black, UIControlState.Normal);
            Intermediate.Layer.CornerRadius = 5;
            Intermediate.Layer.BorderWidth = 0.2f;
            scrollView.AddSubview(Intermediate);

            easy.SetTitle("Easy", UIControlState.Normal);
            easy.SetTitleColor(UIColor.Black, UIControlState.Normal);
            easy.Layer.CornerRadius = 5;
            easy.Layer.BorderWidth = 0.2f;
            scrollView.AddSubview(easy);

            easy.TouchUpInside += (s, e) => {
                easy.BackgroundColor = UIColor.FromRGB(0, 150, 255);
                Intermediate.BackgroundColor = UIColor.White;
                Hard.BackgroundColor = UIColor.White;
                RecipeDifficulty = "easy";
            };

            Intermediate.TouchUpInside += (s, e) => {
                Intermediate.BackgroundColor = UIColor.FromRGB(0, 150, 255);
                easy.BackgroundColor = UIColor.White;
                Hard.BackgroundColor = UIColor.White;
                RecipeDifficulty = "Intermediate";
            };

            Hard.TouchUpInside += (s, e) => {
                Hard.BackgroundColor = UIColor.FromRGB(0, 150, 255);
                Intermediate.BackgroundColor = UIColor.White;
                easy.BackgroundColor = UIColor.White;
                RecipeDifficulty = "Hard";
            };


           

            int YforIngrediant = 540;
            int YforStep = 640;

            base.ViewDidLoad();
            scrollView.ContentSize = new CGSize(View.Frame.Width, View.Frame.Height);
            scrollView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;

            sToolLabel.Center = new CGPoint(100, YforIngrediant -100);
            int YforSpecial = (int)(sToolLabel.Frame.Y + 30);
        
            UITextField label4 = new UITextField(new System.Drawing.RectangleF(20, YforSpecial, 330, 30));
            //label.Placeholder = " Step " + i.ToString();
            label4.Layer.BorderWidth = 1f;
            label4.Layer.CornerRadius = 8;
            IngrediantList.Add(label4);
            scrollView.AddSubview(label4);

            YforSpecial += 50;




            UITextField label1 = new UITextField(new System.Drawing.RectangleF(20, YforIngrediant, 250, 30));
            //label.Placeholder = " Step " + i.ToString();
            label1.Layer.BorderWidth = 1f;
            label1.Layer.CornerRadius = 5;
            IngrediantList.Add(label1);
            scrollView.AddSubview(label1);
            BriefDescInput.Layer.BorderWidth = 1f;
            BriefDescInput.Layer.CornerRadius = 5;

            //AddingrediantButton.Center=new CGPoint(310,YforIngrediant+5);


            // YforStep += 50;

            var AddIngrediantButton = new UIButton(UIButtonType.ContactAdd)
            {
                Frame = new CGRect(300,YforIngrediant, 20,20),
               
            };

            var AddStepButton = new UIButton(UIButtonType.ContactAdd)
            {
                Frame = new CGRect(300, YforStep, 20, 20),


            };
            // creating save button with dynamic movements after additional steps are added
            var btnSaveItem = new UIButton(UIButtonType.Custom)
            {
                Frame = new CGRect(25, YforStep + 80, 320, 40),
                BackgroundColor = UIColor.FromRGB(66,134,244),
              //  Font = UIFont(System, 12)



            };
            AddIngrediantButton.SetTitle("Add Recipe", UIControlState.Normal);
            scrollView.AddSubview(AddIngrediantButton);
            YforIngrediant += 50;
            IngrediantLabel.Center = new CGPoint(106, YforIngrediant - 70);

            //dynamically adding ingredient boxes as plus button is pressed
            AddIngrediantButton.TouchUpInside += (s, e) =>
            {
                UITextField label2 = new UITextField(new System.Drawing.RectangleF(20, YforIngrediant, 250, 30));
                label2.Layer.BorderWidth = 1f;
                label2.Layer.CornerRadius = 5;
                IngrediantList.Add(label2);
                scrollView.AddSubview(label2);

                AddIngrediantButton.Center = new CGPoint(310, YforIngrediant + 15);
                 foreach (UITextView item in PreperationStepsList)
                 {
                     item.Center = new CGPoint(148, item.Frame.Y + 50);

                 }
                 

                YforIngrediant += 50;
               
                InstructionLabel.Center = new CGPoint(80, InstructionLabel.Frame.Y+65);
                AddStepButton.Center = new CGPoint(310, AddStepButton.Frame.Y + 65);
                YforStep += 50;
                textfield += 65;
                scrollView.ContentSize = new CGSize(View.Frame.Width, View.Frame.Height +textview+textfield);
                btnSaveItem.Center = new CGPoint(175, btnSaveItem.Frame.Y + 90);
            };


          
            scrollView.AddSubview(AddStepButton);
            InstructionLabel.Center= new CGPoint(80,YforStep-20);
            UITextView label = new UITextView(new System.Drawing.RectangleF(20, YforStep, 270, 50));
            //label.Placeholder = " Step " + i.ToString();
            label.Layer.BorderWidth = 1f;
            label.Layer.CornerRadius = 5;
            PreperationStepsList.Add(label);
            scrollView.AddSubview(label);

            AddStepButton.Center = new CGPoint(330, YforStep+15);

            YforStep += 70;

            AddStepButton.TouchUpInside += (s, e) =>
            {
               // stepcount++;

                UITextView label3 = new UITextView(new System.Drawing.RectangleF(15, YforStep, 270, 50));
                //label.Placeholder = " Step " + i.ToString();
                label3.Layer.BorderWidth = 1f;
                label3.Layer.CornerRadius = 5;
                PreperationStepsList.Add(label3);
                scrollView.AddSubview(label3);

                AddStepButton.Center = new CGPoint(330, AddStepButton.Frame.Y+ 80);
                textview += 80;
                scrollView.ContentSize = new CGSize(View.Frame.Width, View.Frame.Height + textview + textfield);
                btnSaveItem.Center = new CGPoint(175, btnSaveItem.Frame.Y + 105);
                YforStep += 70;

            };





            btnSaveItem.SetTitle("Save Recipe", UIControlState.Normal);
            btnSaveItem.Layer.CornerRadius = 7;

            scrollView.AddSubview(btnSaveItem);
            btnSaveItem.SetTitleColor(UIColor.White, UIControlState.Normal);
            btnSaveItem.TouchUpInside += (sender, e) =>
            {
               
                if (preptime.Text == null) { preptime.Text = "0"; }
                if (cooktime.Text == null) { cooktime.Text = "0"; }
                var item = new Item
                {
                    name = RecipeName.Text,
                    servings = Convert.ToInt32(ServingSizeInput.Text),
                    preptime = Convert.ToInt32(preptime.Text),
                    cookTime = Convert.ToInt32(cooktime.Text),
                    picture = imgView.Image,
                    ingredients = convertIng(),
                    steps = convertStep(),
                    description = BriefDescInput.Text,
                    // = label4.Text,
                    difficulty = 1,


                   
                };
                ViewModel.AddItemCommand.Execute(item);
                NavigationController.PopToRootViewController(true);
            };

        }



        List<IngredientItem> convertIng(){
            List<IngredientItem> ing=null;
         
            foreach (UITextView item in PreperationStepsList)
            {
                IngredientItem aa = new IngredientItem();
                aa.ingredientId = item.Text;
                ing.Add(aa);

            }
            return ing;

        }
        List<string> convertStep()
        {
            List<string> ing = null; 
            int i = 0;
            foreach (UITextField item in IngrediantList)
            {
                ing.Add(item.Text);

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