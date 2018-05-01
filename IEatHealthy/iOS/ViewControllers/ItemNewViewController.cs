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
        
        public List<IngredientItem> IngrediantList = new List<IngredientItem>();
        public List<UITextView> PreperationStepsList = new List<UITextView>();
        public List<UITextField> SpecialTools = new List<UITextField>();
        public List<UITextField> ingredients = new List<UITextField>();
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
            View.BackgroundColor = UIColor.FromRGB(229, 231, 232);

            Title = "New Recipe";
            int RecipeDifficulty;

            var easy = new UIButton(UIButtonType.Custom)
            {
                Frame = new CGRect(20, DifficultyLabel.Frame.Y + 30, 70, 20),

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

            easy.TouchUpInside += (s, e) =>
            {
                easy.BackgroundColor = UIColor.FromRGB(0, 150, 255);
                Intermediate.BackgroundColor = UIColor.White;
                Hard.BackgroundColor = UIColor.White;
                RecipeDifficulty = 1;
            };

            Intermediate.TouchUpInside += (s, e) =>
            {
                Intermediate.BackgroundColor = UIColor.FromRGB(0, 150, 255);
                easy.BackgroundColor = UIColor.White;
                Hard.BackgroundColor = UIColor.White;
                RecipeDifficulty = 2;
            };

            Hard.TouchUpInside += (s, e) =>
            {
                Hard.BackgroundColor = UIColor.FromRGB(0, 150, 255);
                Intermediate.BackgroundColor = UIColor.White;
                easy.BackgroundColor = UIColor.White;
                RecipeDifficulty = 3;
            };

            BriefDescInput.Layer.BorderWidth = 1f;
            BriefDescInput.Layer.CornerRadius = 5;


            UISegmentedControl ChangeInput = new UISegmentedControl(new CGRect(20, easy.Frame.Y + 40, 330, 30));
            ChangeInput.InsertSegment("Ingredients", 0, false);
            ChangeInput.InsertSegment("Steps", 1, false);
            ChangeInput.InsertSegment("Special Tools", 2, false);
            ChangeInput.SelectedSegment = 0;
            ChangeInput.TintColor = UIColor.Black;
            scrollView.AddSubview(ChangeInput);
      
            scrollView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;





            int YforIngredient = (int)(ChangeInput.Frame.Y + 50);
            int YforSpecial = (int)(ChangeInput.Frame.Y + 50);
            int YforStep = (int)(ChangeInput.Frame.Y + 50);


            UITextField FrstSpecial = new UITextField(new System.Drawing.RectangleF(20, YforSpecial, 270, 30));
            //label.Placeholder = " Step " + i.ToString();
            FrstSpecial.Layer.BorderWidth = 1f;
            FrstSpecial.Layer.CornerRadius = 8;
            FrstSpecial.BackgroundColor = UIColor.White;
            SpecialTools.Add(FrstSpecial);
            //  scrollView.AddSubview(FrstSpecial);


            UITextField FrstIng = new UITextField(new System.Drawing.RectangleF(20, YforIngredient, 250, 30));
            //label.Placeholder = " Step " + i.ToString();
            FrstIng.Layer.BorderWidth = 1f;
            FrstIng.Layer.CornerRadius = 5;
            ingredients.Add(FrstIng);
            scrollView.AddSubview(FrstIng);


            UITextView Frststep = new UITextView(new System.Drawing.RectangleF(15, YforStep, 270, 50));
            //label.Placeholder = " Step " + i.ToString();
            Frststep.Layer.BorderWidth = 1f;
            Frststep.Layer.CornerRadius = 5;
            PreperationStepsList.Add(Frststep);
            //  scrollView.AddSubview(Frststep);

            var AddIngrediantButton = new UIButton(UIButtonType.ContactAdd)
            {
                Frame = new CGRect(340, YforSpecial, 20, 20),
            };
            scrollView.AddSubview(AddIngrediantButton);


            var AddSpecialTool = new UIButton(UIButtonType.ContactAdd)
            {
                Frame = new CGRect(340, YforIngredient, 20, 20),
            };

            var AddStepButton = new UIButton(UIButtonType.ContactAdd)
            {
                Frame = new CGRect(340, YforStep, 20, 20),

            };
            // creating save button with dynamic movements after additional steps are added
            /*
             var btnSaveItem = new UIButton(UIButtonType.Custom)
             {
                 Frame = new CGRect(25, YforStep + 80, 320, 40),
                 BackgroundColor = UIColor.FromRGB(66,134,244),
             };
 */
         

            //dynamically adding ingredient boxes as plus button is pressed
            AddIngrediantButton.TouchUpInside += (s, e) =>
            {
                YforIngredient += 40;
                UITextField label2 = new UITextField(new System.Drawing.RectangleF(20, YforIngredient, 250, 30));
                label2.Layer.BorderWidth = 1f;
                label2.Layer.CornerRadius = 5;
                scrollView.AddSubview(label2);
                ingredients.Add(label2);
                AddIngrediantButton.Center = new CGPoint(310, YforIngredient + 15);
                scrollView.ContentSize = new CGSize(View.Frame.Width, YforIngredient + 60);
            };


            AddStepButton.TouchUpInside += (s, e) =>
            {
                YforStep += 70;
                UITextView label3 = new UITextView(new System.Drawing.RectangleF(15, YforStep, 270, 50));
                label3.Layer.BorderWidth = 1f;
                label3.Layer.CornerRadius = 5;
                label3.BackgroundColor = UIColor.White;
                PreperationStepsList.Add(label3);
                scrollView.AddSubview(label3);

                AddStepButton.Center = new CGPoint(330, AddStepButton.Frame.Y + 80);
                scrollView.ContentSize = new CGSize(View.Frame.Width, YforStep + 60);

            };

            AddSpecialTool.TouchUpInside += (s, e) =>
            {
                YforSpecial += 40;
                UITextField label3 = new UITextField(new System.Drawing.RectangleF(15, YforSpecial, 270, 30));
                label3.Layer.BorderWidth = 1f;
                label3.Layer.CornerRadius = 5;
                label3.BackgroundColor = UIColor.White;
                SpecialTools.Add(label3);
                scrollView.AddSubview(label3);

                AddSpecialTool.Center = new CGPoint(330, AddSpecialTool.Frame.Y+50);
                scrollView.ContentSize = new CGSize(View.Frame.Width, YforSpecial + 60);

            };


     

            ChangeInput.ValueChanged += (sender, e) =>
            {
                var index = ChangeInput.SelectedSegment;

                if (index == 0)
                {
                    foreach (UITextField item in ingredients)
                    { scrollView.AddSubview(item); }

                    scrollView.AddSubview(AddIngrediantButton);
                    AddSpecialTool.RemoveFromSuperview();
                    foreach (UITextField item in SpecialTools)
                    {
                        item.RemoveFromSuperview();
                    }
                    AddSpecialTool.RemoveFromSuperview();

                    foreach (UITextView item in PreperationStepsList)
                    {
                        item.RemoveFromSuperview();
                    }
                    scrollView.AddSubview(AddStepButton);
                    
                }
                if (index == 1)
                {
                   
                   
                   // View.AddSubview(InstructionLabel);
                    foreach (UITextField item in ingredients)
                    { item.RemoveFromSuperview(); }

                    AddIngrediantButton.RemoveFromSuperview();
                    foreach (UITextField item in SpecialTools)
                    {
                        item.RemoveFromSuperview();
                    }
                    AddSpecialTool.RemoveFromSuperview();

                    foreach(UITextView item in PreperationStepsList){
                        scrollView.AddSubview(item);
                    }
                    scrollView.AddSubview(AddStepButton);
                }
                if (index == 2)
                {   
                      foreach (UITextField item in SpecialTools)
                    {    scrollView.AddSubview(item);
                        
                    }
                    foreach (UITextField item in ingredients)
                    { item.RemoveFromSuperview(); }
                        
                    AddStepButton.RemoveFromSuperview();
                    AddIngrediantButton.RemoveFromSuperview();

                    foreach(UITextView item in PreperationStepsList){
                        item.RemoveFromSuperview();
                    }
                    scrollView.AddSubview(AddSpecialTool);

                }

            };
        }

        partial void BtnSaveItem_TouchUpInside(UIButton sender)
        {
            if (preptime.Text == null) { preptime.Text = "0"; }
            if (cooktime.Text == null) { cooktime.Text = "0"; }
            if (ReadyTimeIput.Text == null) { ReadyTimeIput.Text = "0"; }
            var item = new Item
            {
                name = RecipeName.Text,
                servings = Convert.ToInt32(ServingSizeInput.Text),
                prepTime = Convert.ToInt32(preptime.Text),
                cookTime = Convert.ToInt32(cooktime.Text),
                readyInTime = Convert.ToInt32(ReadyTimeIput.Text),
                // picture = imgView.Image,
                ingredients = convertIng(),
                steps = convertStep(),
                description = BriefDescInput.Text,
                // = label4.Text,
                difficulty = 1,



            };
            ViewModel.AddItemCommand.Execute(item);
            NavigationController.PopToRootViewController(true);
        }

        List<IngredientItem> convertIng(){
            List<IngredientItem> ing=new List<IngredientItem>();
         
            foreach (UITextView item in PreperationStepsList)
            {
                IngredientItem aa = new IngredientItem();
                aa.desc = item.Text;
                ing.Add(aa);

            }
            return ing;

        }
        List<string> convertStep()
        {
            List<string> ing = null; 
           
            foreach (IngredientItem item in IngrediantList)
            {
                ing.Add(item.desc);

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