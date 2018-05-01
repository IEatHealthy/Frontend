using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
using CoreGraphics;
using System.Drawing;
using CoreAnimation;

namespace IEatHealthy.iOS
{
    public partial class ItemNewViewController : UIViewController
    {

        public List<IngredientItem> IngrediantList = new List<IngredientItem>();
        public List<UITextView> PreperationStepsList = new List<UITextView>();
        public List<UITextField> SpecialTools = new List<UITextField>();
        public List<UITextField> ingredients = new List<UITextField>();
        UIImagePickerController picker;
        public UIButton ImageBtn { get; private set; }
        public UIImageView ImageView { get; private set; }
        public ItemsViewModel ViewModel { get; set; }

        // Initialize UITextFields
        public UITextField NameText { get; private set; }
        public UITextView DescriptionText { get; private set; }
        public UITextField PrepTimeText { get; private set; }
        public UITextField CookTimeText { get; private set; }
        public UITextField ReadyInText { get; private set; }
        public UITextField ServingSizeText { get; private set; }

        public ItemNewViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            Title = "Craft Recipe";

            this.View.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            var statusBarHeight = UIApplication.SharedApplication.StatusBarFrame.Size.Height;
            var topNavigationHeight = NavigationController.NavigationBar.Frame.Height;
            var startRecipeHeight = statusBarHeight + topNavigationHeight;


            // Recipe Name and Description UIView
            var RecipeName = new UIView();
            RecipeName.Frame = new CGRect(0, startRecipeHeight, View.Bounds.Size.Width, 150);
            RecipeName.BackgroundColor = UIColor.White;
            var border = new CALayer();
            border.BackgroundColor = UIColor.FromRGB(200,200,200).CGColor;
            border.Frame = new CGRect(0, RecipeName.Frame.Size.Height - 1, RecipeName.Frame.Size.Width, 1);
            RecipeName.Layer.AddSublayer(border);

            ImageBtn = new UIButton();
            ImageBtn.Frame = new CGRect(20, 10, 140, 130);
            ImageBtn.TouchUpInside += (s, e) =>
            {
                picker = new UIImagePickerController();
                picker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
                picker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);
                picker.FinishedPickingMedia += Finished;
                picker.Canceled += Canceled;
                PresentViewController(picker, animated: true, completionHandler: null);
            };

            ImageView = new UIImageView();
            ImageView.Frame = new CGRect(20, 10, 140, 130);
            ImageView.Image = UIImage.FromBundle("AddRecipeIcon");

            RecipeName.AddSubview(ImageBtn);
            RecipeName.AddSubview(ImageView);



            var NameLabel = new UILabel();
            NameLabel.Frame = new CGRect(View.Bounds.Size.Width/2 + 10, 10, 10, 10);
            NameLabel.Text = "Name:";
            NameLabel.Font = UIFont.FromName("Helvetica-Light", 14f);
            NameLabel.SizeToFit();
            RecipeName.AddSubview(NameLabel);

            NameText = new UITextField(new CGRect(View.Bounds.Size.Width / 2 + 10, 30, View.Bounds.Width / 2 - 20, 25));
            NameText.BackgroundColor = UIColor.White;
            NameText.Layer.BorderWidth = 1f;
            NameText.Layer.BorderColor = UIColor.FromRGB(200,200,200).CGColor;
            NameText.Layer.CornerRadius = 5;
            NameText.Layer.ShadowRadius = 2f;
            NameText.Layer.ShadowColor = UIColor.FromRGB(100,100,100).CGColor;
            NameText.Layer.ShadowOffset = new CGSize(1.0, 1.0);
            NameText.Layer.ShadowOpacity = 1f;
            NameText.Font = UIFont.FromName("Helvetica-Light", 14f);
            NameText.AdjustsFontSizeToFitWidth = true;
            RecipeName.AddSubview(NameText);

            var DescriptionLabel = new UILabel();
            DescriptionLabel.Frame = new CGRect(View.Bounds.Size.Width / 2 + 10, 60, 10, 10);
            DescriptionLabel.Text = "Description:";
            DescriptionLabel.Font = UIFont.FromName("Helvetica-Light", 14f);
            DescriptionLabel.SizeToFit();
            RecipeName.AddSubview(DescriptionLabel);

            DescriptionText = new UITextView();
            DescriptionText.ContentMode = UIViewContentMode.ScaleAspectFit;
            var DescriptionBox = new UIView(new CGRect(View.Bounds.Size.Width / 2 + 10, 80, View.Bounds.Width/2-20, 50));
            DescriptionText.Frame = DescriptionBox.Bounds;
            DescriptionBox.AddSubview(DescriptionText);

            DescriptionBox.Layer.ShadowRadius = 2f;
            DescriptionBox.Layer.ShadowColor = UIColor.FromRGB(100,100,100).CGColor;
            DescriptionBox.Layer.ShadowOffset = new CGSize(1.0, 1.0);
            DescriptionBox.Layer.ShadowOpacity = 1f;

            DescriptionText.BackgroundColor = UIColor.White;
            DescriptionText.Layer.BorderColor = UIColor.FromRGB(200,200,200).CGColor;
            DescriptionText.Layer.BorderWidth = 1f;
            DescriptionText.Layer.CornerRadius = 5;
            DescriptionText.Font = UIFont.FromName("Helvetica-Light", 14f);
            DescriptionText.ScrollEnabled = true;
            RecipeName.AddSubview(DescriptionBox);

            this.View.AddSubview(RecipeName);


            // Recipe Numbers UIView
            var RecipeNumbers = new UIView();

            var RecipeNumbersPosition = startRecipeHeight + RecipeName.Bounds.Height + 5;
            RecipeNumbers.Frame = new CGRect(0, RecipeNumbersPosition, View.Bounds.Size.Width, 140);
            RecipeNumbers.BackgroundColor = UIColor.White;
            var NumBorder = new CALayer();
            NumBorder.BackgroundColor = UIColor.FromRGB(200, 200, 200).CGColor;
            NumBorder.Frame = new CGRect(0, RecipeNumbers.Frame.Size.Height - 1, RecipeNumbers.Frame.Size.Width, 1);
            RecipeNumbers.Layer.AddSublayer(NumBorder);
            this.View.AddSubview(RecipeNumbers);

            float NumTextWidth = 70;

            // Prep Time
            var PrepTimeLabel = new UILabel();
            PrepTimeLabel.Frame = new CGRect(20, 10, 10, 10);
            PrepTimeLabel.Text = "Prep Time:";
            PrepTimeLabel.Font = UIFont.FromName("Helvetica-Light", 14f);
            PrepTimeLabel.SizeToFit();
            RecipeNumbers.AddSubview(PrepTimeLabel);

            PrepTimeText = new UITextField(new CGRect(20, 30, NumTextWidth, 25));
            PrepTimeText.Layer.BorderColor = UIColor.FromRGB(200, 200, 200).CGColor;
            PrepTimeText.Layer.BorderWidth = 1f;
            PrepTimeText.Layer.CornerRadius = 5;
            PrepTimeText.Layer.ShadowRadius = 2f;
            PrepTimeText.Layer.ShadowColor = UIColor.FromRGB(100,100,100).CGColor;
            PrepTimeText.Layer.ShadowOffset = new CGSize(1.0, 1.0);
            PrepTimeText.Layer.ShadowOpacity = 1f;
            PrepTimeText.BackgroundColor = UIColor.White;
            PrepTimeText.Font = UIFont.FromName("Helvetica-Light", 14f);
            PrepTimeText.AdjustsFontSizeToFitWidth = true;
            RecipeNumbers.AddSubview(PrepTimeText);

            // Cook Time
            var CookTimeLabel = new UILabel();
            CookTimeLabel.Frame = new CGRect(View.Bounds.Size.Width / 2 + 10, 10, 10, 10);
            CookTimeLabel.Text = "Cook Time:";
            CookTimeLabel.Font = UIFont.FromName("Helvetica-Light", 14f);
            CookTimeLabel.SizeToFit();
            RecipeNumbers.AddSubview(CookTimeLabel);

            CookTimeText = new UITextField(new CGRect(View.Bounds.Width / 2 + 10, 30, NumTextWidth, 25));
            CookTimeText.Layer.BorderWidth = 1f;
            CookTimeText.Layer.BorderColor = UIColor.FromRGB(200, 200, 200).CGColor;
            CookTimeText.Layer.CornerRadius = 5;
            CookTimeText.Layer.ShadowRadius = 2f;
            CookTimeText.Layer.ShadowColor = UIColor.FromRGB(100, 100, 100).CGColor;
            CookTimeText.Layer.ShadowOffset = new CGSize(1.0, 1.0);
            CookTimeText.Layer.ShadowOpacity = 1f;
            CookTimeText.BackgroundColor = UIColor.White;
            CookTimeText.Font = UIFont.FromName("Helvetica-Light", 14f);
            CookTimeText.AdjustsFontSizeToFitWidth = true;
            RecipeNumbers.AddSubview(CookTimeText);

            // Ready In
            var ReadyInLabel = new UILabel();
            ReadyInLabel.Frame = new CGRect(20, 75, 10, 10);
            ReadyInLabel.Text = "Ready In:";
            ReadyInLabel.Font = UIFont.FromName("Helvetica-Light", 14f);
            ReadyInLabel.SizeToFit();
            RecipeNumbers.AddSubview(ReadyInLabel);

            ReadyInText = new UITextField(new CGRect(20, 95, NumTextWidth, 25));
            ReadyInText.Layer.BorderWidth = 1f;
            ReadyInText.Layer.BorderColor = UIColor.FromRGB(200, 200, 200).CGColor;
            ReadyInText.Layer.CornerRadius = 5;
            ReadyInText.Layer.ShadowRadius = 2f;
            ReadyInText.Layer.ShadowColor = UIColor.FromRGB(100, 100, 100).CGColor;
            ReadyInText.Layer.ShadowOffset = new CGSize(1.0, 1.0);
            ReadyInText.Layer.ShadowOpacity = 1f;
            ReadyInText.BackgroundColor = UIColor.White;
            ReadyInText.Font = UIFont.FromName("Helvetica-Light", 14f);
            ReadyInText.AdjustsFontSizeToFitWidth = true;
            RecipeNumbers.AddSubview(ReadyInText);

            // Serving Size
            var ServingSizeLabel = new UILabel();
            ServingSizeLabel.Frame = new CGRect(View.Bounds.Size.Width / 2 + 10, 75, 10, 10);
            ServingSizeLabel.Text = "Serving Size:";
            ServingSizeLabel.Font = UIFont.FromName("Helvetica-Light", 14f);
            ServingSizeLabel.SizeToFit();
            RecipeNumbers.AddSubview(ServingSizeLabel);

            ServingSizeText = new UITextField(new CGRect(View.Bounds.Size.Width / 2 + 10, 95, NumTextWidth, 25));
            ServingSizeText.Layer.BorderWidth = 1f;
            ServingSizeText.Layer.BorderColor = UIColor.FromRGB(200, 200, 200).CGColor;
            ServingSizeText.Layer.CornerRadius = 5;
            ServingSizeText.Layer.ShadowRadius = 2f;
            ServingSizeText.Layer.ShadowColor = UIColor.FromRGB(100, 100, 100).CGColor;
            ServingSizeText.Layer.ShadowOffset = new CGSize(1.0, 1.0);
            ServingSizeText.Layer.ShadowOpacity = 1f;
            ServingSizeText.BackgroundColor = UIColor.White;
            ServingSizeText.Font = UIFont.FromName("Helvetica-Light", 14f);
            ServingSizeText.AdjustsFontSizeToFitWidth = true;
            RecipeNumbers.AddSubview(ServingSizeText);

            var DifficultyPosition = RecipeNumbersPosition + RecipeNumbers.Bounds.Height + 5;
            var DifficultyButtons = new UIView();

            DifficultyButtons.Frame = new CGRect(0, DifficultyPosition, View.Bounds.Size.Width, 100);
            DifficultyButtons.BackgroundColor = UIColor.White;
            var DifficultyBorder = new CALayer();
            DifficultyBorder.BackgroundColor = UIColor.FromRGB(200, 200, 200).CGColor;
            DifficultyBorder.Frame = new CGRect(0, DifficultyButtons.Frame.Size.Height - 1, DifficultyBorder.Frame.Size.Width, 1);
            DifficultyButtons.Layer.AddSublayer(DifficultyBorder);
            this.View.AddSubview(DifficultyButtons);

            var DifficultyLabel = new UILabel();
            DifficultyLabel.Frame = new CGRect(20, 10, 10, 10);
            DifficultyLabel.Text = "Difficulty";
            DifficultyLabel.Font = UIFont.FromName("Helvetica-Light", 14f);
            DifficultyLabel.SizeToFit();
            DifficultyButtons.AddSubview(DifficultyLabel);


            int RecipeDifficulty;

            var easy = new UIButton(UIButtonType.Custom)
            {
                Frame = new CGRect(20, 50, 70, 20),
            };
            var Intermediate = new UIButton(UIButtonType.Custom)
            {
                Frame = new CGRect(100, 50, 140, 20),
            };
            var Hard = new UIButton(UIButtonType.Custom)
            {
                Frame = new CGRect(260, 50, 70, 20),
            };


            Hard.SetTitleColor(UIColor.Black, UIControlState.Normal);
            Hard.SetTitle("Hard", UIControlState.Normal);
            Hard.Layer.BorderWidth = 0.2f;
            Hard.Layer.CornerRadius = 5;
            DifficultyButtons.AddSubview(Hard);

            Intermediate.SetTitle("Intermediate", UIControlState.Normal);
            Intermediate.SetTitleColor(UIColor.Black, UIControlState.Normal);
            Intermediate.Layer.CornerRadius = 5;
            Intermediate.Layer.BorderWidth = 0.2f;
            DifficultyButtons.AddSubview(Intermediate);

            easy.SetTitle("Easy", UIControlState.Normal);
            easy.SetTitleColor(UIColor.Black, UIControlState.Normal);
            easy.Layer.CornerRadius = 5;
            easy.Layer.BorderWidth = 0.2f;
            DifficultyButtons.AddSubview(easy);

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

            // SegControl UIView
            var SegControlPosition = DifficultyPosition + DifficultyButtons.Bounds.Height + 5;
            var scrollView = new UIScrollView();
            scrollView.Frame = new CGRect(0, SegControlPosition, View.Bounds.Size.Width, 300);
            scrollView.BackgroundColor = UIColor.White;
            this.View.AddSubview(scrollView);

            // The SegControl
            var ChangeInput = new UISegmentedControl();
            UISegmentedControl.AppearanceWhenContainedIn();
            ChangeInput.Frame = new CGRect(0, 5, View.Bounds.Size.Width, 40);
            ChangeInput.BackgroundColor = UIColor.White;
            ChangeInput.TintColor = UIColor.Clear;

            ChangeInput.InsertSegment("Ingredients", 0, false);
            ChangeInput.InsertSegment("Steps", 1, false);
            ChangeInput.InsertSegment("Special Tools", 2, false);
            ChangeInput.SetTitleTextAttributes(new UITextAttributes()
            {
                TextColor = UIColor.Black,
                Font = UIFont.FromName("Helvetica-Bold", 14f),
                TextShadowColor = UIColor.Clear
            }, UIControlState.Normal);

            ChangeInput.SetTitleTextAttributes(new UITextAttributes()
            {
                TextColor = UIColor.Red,
                Font = UIFont.FromName("Helvetica-Bold", 14f),
                TextShadowColor = UIColor.Clear
            }, UIControlState.Selected);

            ChangeInput.SelectedSegment = 0;
            scrollView.AddSubview(ChangeInput);



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

                AddSpecialTool.Center = new CGPoint(330, AddSpecialTool.Frame.Y + 50);
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
                    AddStepButton.RemoveFromSuperview();
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

                    foreach (UITextView item in PreperationStepsList)
                    {
                        scrollView.AddSubview(item);
                    }
                    scrollView.AddSubview(AddStepButton);
                }
                if (index == 2)
                {
                    foreach (UITextField item in SpecialTools)
                    {
                        scrollView.AddSubview(item);

                    }
                    foreach (UITextField item in ingredients)
                    { item.RemoveFromSuperview(); }

                    AddStepButton.RemoveFromSuperview();
                    AddIngrediantButton.RemoveFromSuperview();

                    foreach (UITextView item in PreperationStepsList)
                    {
                        item.RemoveFromSuperview();
                    }
                    scrollView.AddSubview(AddSpecialTool);

                }

            };
        }



        partial void BtnSaveItem_TouchUpInside(UIButton sender)
        {
            if (PrepTimeText.Text == null) { PrepTimeText.Text = "0"; }
            if (CookTimeText.Text == null) { CookTimeText.Text = "0"; }
            if (ReadyInText.Text == null) { ReadyInText.Text = "0"; }
            var item = new Item
            {
                name = NameText.Text,
                servings = Convert.ToInt32(ServingSizeText.Text),
                prepTime = Convert.ToInt32(PrepTimeText.Text),
                cookTime = Convert.ToInt32(CookTimeText.Text),
                readyInTime = Convert.ToInt32(ReadyInText.Text),
                // picture = imgView.Image,
                ingredients = convertIng(),
                steps = convertStep(),
                description = DescriptionText.Text,
                // = label4.Text,
                difficulty = 1,
            };
            ViewModel.AddItemCommand.Execute(item);
            NavigationController.PopToRootViewController(true);
        }

        List<IngredientItem> convertIng()
        {
            List<IngredientItem> ing = new List<IngredientItem>();

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
                    ImageView.Image = originalImage;
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
