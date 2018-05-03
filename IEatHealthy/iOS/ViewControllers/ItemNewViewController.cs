using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
using CoreGraphics;
using System.Drawing;
using CoreAnimation;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace IEatHealthy.iOS
{
    public partial class ItemNewViewController : UIViewController
    {

        public List<IngredientItem> IngrediantList = new List<IngredientItem>();
        public List<Steps> PreparationStepsList = new List<Steps>();
        public List<Tools> SpecialTools = new List<Tools>();
        public List<Ingre> ingredients = new List<Ingre>();
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

        public static AppDelegate App
        {
            get { return (AppDelegate)UIApplication.SharedApplication.Delegate; }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            Title = "Craft Recipe";

            // Initial Height of scrollView
            this.View.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            var statusBarHeight = UIApplication.SharedApplication.StatusBarFrame.Size.Height;
            var topNavigationHeight = NavigationController.NavigationBar.Frame.Height;
            var startRecipeHeight = statusBarHeight + topNavigationHeight;

            // Initialize scrollview
            var scrollView = new UIScrollView();
            scrollView.Frame = new CGRect(0, startRecipeHeight, View.Bounds.Size.Width, View.Bounds.Size.Height - startRecipeHeight - NavigationController.TabBarController.TabBar.Bounds.Height);
            scrollView.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            scrollView.PagingEnabled = true;
            scrollView.ContentSize = new CGSize(View.Bounds.Size.Width, 1500);
            this.View.AddSubview(scrollView);

            // Recipe Name and Description UIView
            var RecipeName = new UIView();
            RecipeName.Frame = new CGRect(0, 0, View.Bounds.Size.Width, 150);
            RecipeName.BackgroundColor = UIColor.White;
            var border = new CALayer();
            border.BackgroundColor = UIColor.FromRGB(200, 200, 200).CGColor;
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
            NameLabel.Frame = new CGRect(View.Bounds.Size.Width / 2 + 10, 10, 10, 10);
            NameLabel.Text = "Name:";
            NameLabel.Font = UIFont.FromName("Helvetica-Light", 14f);
            NameLabel.SizeToFit();
            RecipeName.AddSubview(NameLabel);

            NameText = new UITextField(new CGRect(View.Bounds.Size.Width / 2 + 10, 30, View.Bounds.Width / 2 - 20, 25));
            NameText.BackgroundColor = UIColor.White;
            NewTextField(NameText);
            RecipeName.AddSubview(NameText);

            var DescriptionLabel = new UILabel();
            DescriptionLabel.Frame = new CGRect(View.Bounds.Size.Width / 2 + 10, 60, 10, 10);
            DescriptionLabel.Text = "Description:";
            DescriptionLabel.Font = UIFont.FromName("Helvetica-Light", 14f);
            DescriptionLabel.SizeToFit();
            RecipeName.AddSubview(DescriptionLabel);

            DescriptionText = new UITextView();
            DescriptionText.ContentMode = UIViewContentMode.ScaleAspectFit;
            var DescriptionBox = new UIView(new CGRect(View.Bounds.Size.Width / 2 + 10, 80, View.Bounds.Width / 2 - 20, 50));
            DescriptionText.Frame = DescriptionBox.Bounds;
            DescriptionBox.AddSubview(DescriptionText);

            DescriptionBox.Layer.ShadowRadius = 2f;
            DescriptionBox.Layer.ShadowColor = UIColor.FromRGB(100, 100, 100).CGColor;
            DescriptionBox.Layer.ShadowOffset = new CGSize(1.0, 1.0);
            DescriptionBox.Layer.ShadowOpacity = 1f;
            DescriptionText.Text = App.currentAccount.email;
            DescriptionText.BackgroundColor = UIColor.White;
            DescriptionText.Layer.BorderColor = UIColor.FromRGB(200, 200, 200).CGColor;
            DescriptionText.Layer.BorderWidth = 1f;
            DescriptionText.Layer.CornerRadius = 5;
            DescriptionText.Font = UIFont.FromName("Helvetica-Light", 14f);
            DescriptionText.ScrollEnabled = true;
            RecipeName.AddSubview(DescriptionBox);

            scrollView.AddSubview(RecipeName);

            // Recipe Numbers UIView
            var RecipeNumbers = new UIView();

            var RecipeNumbersPosition = RecipeName.Bounds.Height + 5;
            RecipeNumbers.Frame = new CGRect(0, RecipeNumbersPosition, View.Bounds.Size.Width, 140);
            RecipeNumbers.BackgroundColor = UIColor.White;
            var NumBorder = new CALayer();
            NumBorder.BackgroundColor = UIColor.FromRGB(200, 200, 200).CGColor;
            NumBorder.Frame = new CGRect(0, RecipeNumbers.Frame.Size.Height - 1, RecipeNumbers.Frame.Size.Width, 1);
            RecipeNumbers.Layer.AddSublayer(NumBorder);
            scrollView.AddSubview(RecipeNumbers);

            float NumTextWidth = 70;

            // Prep Time
            var PrepTimeLabel = new UILabel();
            PrepTimeLabel.Frame = new CGRect(20, 10, 10, 10);
            PrepTimeLabel.Text = "Prep Time:";
            PrepTimeLabel.Font = UIFont.FromName("Helvetica-Light", 14f);
            PrepTimeLabel.SizeToFit();
            RecipeNumbers.AddSubview(PrepTimeLabel);

            PrepTimeText = new UITextField(new CGRect(20, 30, NumTextWidth, 25));
            NewTextField(PrepTimeText);
            RecipeNumbers.AddSubview(PrepTimeText);

            // Cook Time
            var CookTimeLabel = new UILabel();
            CookTimeLabel.Frame = new CGRect(View.Bounds.Size.Width / 2 + 10, 10, 10, 10);
            CookTimeLabel.Text = "Cook Time:";
            CookTimeLabel.Font = UIFont.FromName("Helvetica-Light", 14f);
            CookTimeLabel.SizeToFit();
            RecipeNumbers.AddSubview(CookTimeLabel);

            CookTimeText = new UITextField(new CGRect(View.Bounds.Width / 2 + 10, 30, NumTextWidth, 25));
            NewTextField(CookTimeText);
            RecipeNumbers.AddSubview(CookTimeText);

            // Ready In
            var ReadyInLabel = new UILabel();
            ReadyInLabel.Frame = new CGRect(20, 75, 10, 10);
            ReadyInLabel.Text = "Ready In:";
            ReadyInLabel.Font = UIFont.FromName("Helvetica-Light", 14f);
            ReadyInLabel.SizeToFit();
            RecipeNumbers.AddSubview(ReadyInLabel);

            ReadyInText = new UITextField(new CGRect(20, 95, NumTextWidth, 25));
            NewTextField(ReadyInText);
            RecipeNumbers.AddSubview(ReadyInText);

            // Serving Size
            var ServingSizeLabel = new UILabel();
            ServingSizeLabel.Frame = new CGRect(View.Bounds.Size.Width / 2 + 10, 75, 10, 10);
            ServingSizeLabel.Text = "Serving Size:";
            ServingSizeLabel.Font = UIFont.FromName("Helvetica-Light", 14f);
            ServingSizeLabel.SizeToFit();
            RecipeNumbers.AddSubview(ServingSizeLabel);

            ServingSizeText = new UITextField(new CGRect(View.Bounds.Size.Width / 2 + 10, 95, NumTextWidth, 25));
            NewTextField(ServingSizeText);
            RecipeNumbers.AddSubview(ServingSizeText);

            // Difficulty Buttons
            var DifficultyPosition = RecipeNumbersPosition + RecipeNumbers.Bounds.Height + 5;
            var DifficultyButtons = new UIView();

            DifficultyButtons.Frame = new CGRect(0, DifficultyPosition, View.Bounds.Size.Width, 100);
            DifficultyButtons.BackgroundColor = UIColor.White;
            var DifficultyBorder = new CALayer();
            DifficultyBorder.BackgroundColor = UIColor.FromRGB(200, 200, 200).CGColor;
            DifficultyBorder.Frame = new CGRect(0, DifficultyButtons.Frame.Size.Height - 1, DifficultyBorder.Frame.Size.Width, 1);
            DifficultyButtons.Layer.AddSublayer(DifficultyBorder);
            scrollView.AddSubview(DifficultyButtons);

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

            // SegControl
            var SegControlPosition = DifficultyPosition + DifficultyButtons.Bounds.Height + 5;
            var ChangeInput = new UISegmentedControl();
            UISegmentedControl.AppearanceWhenContainedIn();
            ChangeInput.Frame = new CGRect(0, SegControlPosition, View.Bounds.Size.Width, 40);
            ChangeInput.BackgroundColor = UIColor.White;
            ChangeInput.TintColor = UIColor.Clear;

            ChangeInput.InsertSegment("Ingredients", 0, false);
            ChangeInput.InsertSegment("Steps", 1, false);
            ChangeInput.InsertSegment("Special Tools", 2, false);
            ChangeInput.SetTitleTextAttributes(new UITextAttributes()
            {
                TextColor = UIColor.Black,
                Font = UIFont.FromName("Helvetica-Light", 14f),
                TextShadowColor = UIColor.Clear
            }, UIControlState.Normal);

            ChangeInput.SetTitleTextAttributes(new UITextAttributes()
            {
                TextColor = UIColor.Red,
                Font = UIFont.FromName("Helvetica-Light", 14f),
                TextShadowColor = UIColor.Clear
            }, UIControlState.Selected);

            ChangeInput.SelectedSegment = 0;
            scrollView.AddSubview(ChangeInput);

            var IngredientPosition = SegControlPosition + ChangeInput.Bounds.Height;
            var SpecialToolsPosition = SegControlPosition + ChangeInput.Bounds.Height;
            var StepsPosition = SegControlPosition + ChangeInput.Bounds.Height;

            // First Ingredient
            Ingre ingre = new Ingre();
            UIView FirstIngredientView = new UIView(new CGRect(0, IngredientPosition, View.Bounds.Width, 40));
            FirstIngredientView.BackgroundColor = UIColor.White;

            UITextField FirstIngredientAmount = new UITextField(new CGRect(20, 5, 90, 25));
            NewTextField(FirstIngredientAmount);
            FirstIngredientAmount.Placeholder = "Amount";

            UITextField FirstIngredientUnit = new UITextField(new CGRect(120, 5, 90, 25));
            NewTextField(FirstIngredientUnit);
            FirstIngredientUnit.Placeholder = "Unit of Measure";

            UITextField FirstIngredientName = new UITextField(new CGRect(220, 5, 90, 25));
            NewTextField(FirstIngredientName);
            FirstIngredientName.Placeholder = "Name";

            ingre.background = FirstIngredientView;
            ingre.Amount = FirstIngredientAmount;
            ingre.Unit = FirstIngredientUnit;
            ingre.Name = FirstIngredientName;
            ingredients.Add(ingre);

            var AddIngredientButton = new UIButton(UIButtonType.ContactAdd)
            {
                Frame = new CGRect(View.Bounds.Width - 40, 5, 20, 20),
            };
            FirstIngredientView.AddSubview(FirstIngredientAmount);
            FirstIngredientView.AddSubview(FirstIngredientUnit);
            FirstIngredientView.AddSubview(FirstIngredientName);
            FirstIngredientView.AddSubview(AddIngredientButton);

            scrollView.AddSubview(FirstIngredientView);

            // First StepView

            Steps step = new Steps();
            UIView FirstStepView = new UIView(new CGRect(0, StepsPosition, View.Bounds.Width, 70));
            FirstStepView.BackgroundColor = UIColor.White;
            UITextView FirstStep = new UITextView();
            FirstStep.ContentMode = UIViewContentMode.ScaleAspectFit;
            UIView ShadowStep = new UIView(new CGRect(20, 5, 200, 60));
            FirstStep.Frame = ShadowStep.Bounds;
            ShadowStep.AddSubview(FirstStep);

            ShadowStep.Layer.ShadowRadius = 2f;
            ShadowStep.Layer.ShadowColor = UIColor.FromRGB(100, 100, 100).CGColor;
            ShadowStep.Layer.ShadowOffset = new CGSize(1.0, 1.0);
            ShadowStep.Layer.ShadowOpacity = 1f;

            FirstStep.BackgroundColor = UIColor.White;
            FirstStep.Layer.BorderColor = UIColor.FromRGB(200, 200, 200).CGColor;
            FirstStep.Layer.BorderWidth = 1f;
            FirstStep.Layer.CornerRadius = 5;
            FirstStep.Font = UIFont.FromName("Helvetica-Light", 14f);
            FirstStep.ScrollEnabled = true;
            FirstStepView.AddSubview(ShadowStep);

            step.background = FirstStepView;
            step.shadow = ShadowStep;
            step.Step = FirstStep;
            PreparationStepsList.Add(step);


            var AddStepButton = new UIButton(UIButtonType.ContactAdd)
            {
                Frame = new CGRect(View.Bounds.Width - 40, 5, 20, 20),
            };
            FirstStepView.AddSubview(AddStepButton);

            // First Tool 
            Tools tool = new Tools();
            UIView FirstSpecialToolView = new UIView(new CGRect(0, SpecialToolsPosition, View.Bounds.Width, 40));
            FirstSpecialToolView.BackgroundColor = UIColor.White;
            UITextField FirstSpecialTool = new UITextField(new CGRect(20, 5, 100, 25));
            NewTextField(FirstSpecialTool);

            tool.background = FirstSpecialToolView;
            tool.Name = FirstSpecialTool;
            SpecialTools.Add(tool);
            var AddSpecialToolButton = new UIButton(UIButtonType.ContactAdd)
            {
                Frame = new CGRect(View.Bounds.Width - 40, 5, 20, 20),
            };
            FirstSpecialToolView.AddSubview(AddSpecialToolButton);



            // Add to ingredient list
            AddIngredientButton.TouchUpInside += (s, e) =>
            {
                Ingre ingredient = new Ingre();
                AddIngredientButton.RemoveFromSuperview();
                IngredientPosition += 40;
                UIView newIngredientView = new UIView(new CGRect(0, IngredientPosition, View.Bounds.Width, 40));
                newIngredientView.BackgroundColor = UIColor.White;
                UITextField newIngredientAmount = new UITextField(new CGRect(20, 5, 90, 25));
                UITextField newIngredientUnit = new UITextField(new CGRect(120, 5, 90, 25));
                UITextField newIngredientName = new UITextField(new CGRect(220, 5, 90, 25));
                NewTextField(newIngredientAmount);
                NewTextField(newIngredientUnit);
                NewTextField(newIngredientName);
                newIngredientAmount.Placeholder = "Amount";
                newIngredientUnit.Placeholder = "Unit of Measure";
                newIngredientName.Placeholder = "Name";
                newIngredientView.AddSubview(newIngredientAmount);
                newIngredientView.AddSubview(newIngredientUnit);
                newIngredientView.AddSubview(newIngredientName);
                newIngredientView.AddSubview(AddIngredientButton);
                ingredient.background = newIngredientView;
                ingredient.Amount = newIngredientAmount;
                ingredient.Unit = newIngredientUnit;
                ingredient.Name = newIngredientName;
                ingredients.Add(ingredient);
                scrollView.AddSubview(newIngredientView);
            };

            // Add to preparation step list
            AddStepButton.TouchUpInside += (s, e) =>
            {
                Steps steps = new Steps();
                StepsPosition += 70;
                AddStepButton.RemoveFromSuperview();
                UIView newStepView = new UIView(new CGRect(0, StepsPosition, View.Bounds.Width, 70));
                newStepView.BackgroundColor = UIColor.White;
                UITextView newStep = new UITextView();
                newStep.ContentMode = UIViewContentMode.ScaleAspectFit;
                UIView newShadowStep = new UIView(new CGRect(20, 5, 200, 60));
                newStep.Frame = newShadowStep.Bounds;
                newShadowStep.AddSubview(newStep);

                newShadowStep.Layer.ShadowRadius = 2f;
                newShadowStep.Layer.ShadowColor = UIColor.FromRGB(100, 100, 100).CGColor;
                newShadowStep.Layer.ShadowOffset = new CGSize(1.0, 1.0);
                newShadowStep.Layer.ShadowOpacity = 1f;

                newStep.BackgroundColor = UIColor.White;
                newStep.Layer.BorderColor = UIColor.FromRGB(200, 200, 200).CGColor;
                newStep.Layer.BorderWidth = 1f;
                newStep.Layer.CornerRadius = 5;
                newStep.Font = UIFont.FromName("Helvetica-Light", 14f);
                newStep.ScrollEnabled = true;
                newStepView.AddSubview(newShadowStep);
                newStepView.AddSubview(AddStepButton);

                steps.background = newStepView;
                steps.shadow = newShadowStep;
                steps.Step = newStep;
                PreparationStepsList.Add(steps);
                scrollView.AddSubview(newStepView);
            };

            // Add to Special Tools list
            AddSpecialToolButton.TouchUpInside += (s, e) =>
            {
                Tools tools = new Tools();
                AddSpecialToolButton.RemoveFromSuperview();
                SpecialToolsPosition += 40;
                UIView newSpecialToolsView = new UIView(new CGRect(0, SpecialToolsPosition, View.Bounds.Width, 40));
                newSpecialToolsView.BackgroundColor = UIColor.White;
                UITextField newSpecialTool = new UITextField(new CGRect(20, 5, 100, 25));
                NewTextField(newSpecialTool);
                newSpecialToolsView.AddSubview(newSpecialTool);
                newSpecialToolsView.AddSubview(AddSpecialToolButton);
                tools.background = newSpecialToolsView;
                tools.Name = newSpecialTool;
                SpecialTools.Add(tools);
                scrollView.AddSubview(newSpecialToolsView);
            };

            ChangeInput.ValueChanged += (sender, e) =>
            {
                var index = ChangeInput.SelectedSegment;

                switch (index)
                {
                    case 0:
                        // add all ingredient subviews
                        foreach (Ingre item in ingredients)
                        {
                            scrollView.AddSubview(item.background);
                            item.background.AddSubview(item.Amount);
                            item.background.AddSubview(item.Unit);
                            item.background.AddSubview(item.Name);
                        }

                        // remove all step subviews
                        foreach (Steps item in PreparationStepsList)
                        {
                            item.background.RemoveFromSuperview();
                            item.shadow.RemoveFromSuperview();
                            item.Step.RemoveFromSuperview();
                        }

                        // remove all tool subviews
                        foreach (Tools item in SpecialTools)
                        {
                            item.background.RemoveFromSuperview();
                            item.Name.RemoveFromSuperview();
                        }
                        break;
                    case 1:
                        // remove all ingredient subviews
                        foreach (Ingre item in ingredients)
                        {
                            item.background.RemoveFromSuperview();
                            item.Amount.RemoveFromSuperview();
                            item.Name.RemoveFromSuperview();
                            item.Unit.RemoveFromSuperview();
                        }

                        // add all step subviews
                        foreach (Steps item in PreparationStepsList)
                        {
                            scrollView.AddSubview(item.background);
                            item.shadow.AddSubview(item.Step);
                            item.background.AddSubview(item.shadow);
                        }

                        // remove all tool subviews
                        foreach (Tools item in SpecialTools)
                        {
                            item.background.RemoveFromSuperview();
                            item.Name.RemoveFromSuperview();
                        }

                        break;
                    case 2:
                        foreach (Ingre item in ingredients)
                        {
                            item.background.RemoveFromSuperview();
                            item.Amount.RemoveFromSuperview();
                            item.Name.RemoveFromSuperview();
                            item.Unit.RemoveFromSuperview();
                        }

                        foreach (Steps item in PreparationStepsList)
                        {
                            item.background.RemoveFromSuperview();
                            item.shadow.RemoveFromSuperview();
                            item.Step.RemoveFromSuperview();
                        }

                        foreach (Tools item in SpecialTools)
                        {
                            scrollView.AddSubview(item.background);
                            item.background.AddSubview(item.Name);
                        }
                        break;
                }
            };
        
        }

        void NewTextField(UITextField textbox)
        {
            textbox.Layer.BorderColor = UIColor.FromRGB(200, 200, 200).CGColor;
            textbox.Layer.BorderWidth = 1f;
            textbox.Layer.CornerRadius = 5;
            textbox.Layer.ShadowRadius = 2f;
            textbox.Layer.ShadowColor = UIColor.FromRGB(100, 100, 100).CGColor;
            textbox.Layer.ShadowOffset = new CGSize(1.0, 1.0);
            textbox.Layer.ShadowOpacity = 1f;
            textbox.BackgroundColor = UIColor.White;
            textbox.Font = UIFont.FromName("Helvetica-Light", 14f);
            textbox.AdjustsFontSizeToFitWidth = true;
        }

        void NewTextView(UITextView textbox, UIView shadowbox)
        {
            textbox.ContentMode = UIViewContentMode.ScaleAspectFit;
            shadowbox.Layer.ShadowRadius = 2f;
            shadowbox.Layer.ShadowColor = UIColor.FromRGB(100, 100, 100).CGColor;
            shadowbox.Layer.ShadowOffset = new CGSize(1.0, 1.0);
            shadowbox.Layer.ShadowOpacity = 1f;

            textbox.BackgroundColor = UIColor.White;
            textbox.Layer.BorderColor = UIColor.FromRGB(200, 200, 200).CGColor;
            textbox.Layer.BorderWidth = 1f;
            textbox.Layer.CornerRadius = 5;
            textbox.Font = UIFont.FromName("Helvetica-Light", 14f);
            textbox.ScrollEnabled = true;
        }
        //public class IngredientItem
        //{
        //    public string unitOfMeasure { get; set; }
        //    public float amount { get; set; }
        //    public string desc { get; set; }
        //}

        partial void BtnSaveItem_TouchUpInside(UIButton sender)
        {
            NSData data = ImageView.Image.AsPNG();
            String img64 = data.GetBase64EncodedString(NSDataBase64EncodingOptions.None);

            if (PrepTimeText.Text == null) { PrepTimeText.Text = "0"; }
            if (CookTimeText.Text == null) { CookTimeText.Text = "0"; }
            if (ReadyInText.Text == null) { ReadyInText.Text = "0"; }


            var item = new SubmitItem
            {
                name = NameText.Text,
                servings = Convert.ToInt32(ServingSizeText.Text),
                prepTime = Convert.ToInt32(PrepTimeText.Text),
                cookTime = Convert.ToInt32(CookTimeText.Text),
                readyInTime = Convert.ToInt32(ReadyInText.Text),
                ingredients = convertIng(),
                steps = convertSteps(),
                toolsNeeded = convertTools(),
                description = DescriptionText.Text,
                difficulty = 1,
                typeOfFood = 30,
                author = App.currentAccount.username,
                foodImage = img64
            };

            PostRecipe(item);
            NavigationController.PopToRootViewController(true);
       }
        public async Task PostRecipe(SubmitItem item)
        {
            var request = HttpWebRequest.Create(string.Format(@"http://ieathealthy.info/api/recipe?email={0}&token={1}",App.currentAccount.email, App.currentAccount.JWTToken));

            request.ContentType = "application/json";
            request.Method = "POST";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(item);

                streamWriter.Write(json);
            }
           
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }

            catch (System.Net.WebException err){

                DescriptionText.Text = err.ToString();
            }
        }

        List<IngredientItem> convertIng()
        {
            List<IngredientItem> ing = new List<IngredientItem>();

            foreach (Ingre item in ingredients)
            {
                IngredientItem temp = new IngredientItem();

                if (item.Amount.Text == null) { temp.amount = 0; }
                else
                {
                    temp.amount = (float)Convert.ToInt32(item.Amount.Text);
                }
                temp.unitOfMeasure = item.Unit.Text;
                temp.desc = item.Name.Text;
                ing.Add(temp);
            }
            return ing;
        }

        List<string> convertSteps() {
            List<string> steps = new List<string>();

            foreach (Steps temp in PreparationStepsList)
            {
                steps.Add(temp.Step.Text);
            }
            return steps;
        }

        List<string> convertTools() {
            List<string> tools = new List<string>();

            foreach (Tools temp in SpecialTools)
            {
                tools.Add(temp.Name.Text);
            }
            return tools;
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

    public class Ingre
    {
        public UIView background { get; set; }
        public UITextField Name { get; set; }
        public UITextField Unit { get; set; }
        public UITextField Amount { get; set; }
    }

    public class Tools
    {
        public UIView background { get; set; }
        public UITextField Name { get; set; }
    }

    public class Steps
    {
        public UIView background { get; set; }
        public UIView shadow { get; set; }
        public UITextView Step { get; set; }
    }
}
