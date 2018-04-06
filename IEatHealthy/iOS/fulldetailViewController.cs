using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace IEatHealthy.iOS
{
    public partial class FullDetailViewController : UIViewController
    {
        public FullDetailViewController(IntPtr handle) : base(handle)
        {
        }

        UIScrollView scrollView = new UIScrollView();



        public Item mm = new Item { };
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //lav.Text = mm.Text;
            scrollView = new UIScrollView(new CGRect(View.Frame.X, View.Frame.Y, View.Frame.Width, 1000));
            scrollView.ContentSize = View.Frame.Size;

            View.AddSubview(scrollView);
            var AddStepButton = new UIButton(UIButtonType.Custom)
            {
                Frame = new CGRect(20, 71, View.Bounds.Width - 40, 45),
                BackgroundColor = UIColor.FromRGB(0, 0.5f, 0),
            };


            scrollView.AddSubview(AddStepButton);


            AddStepButton.TouchUpInside += (s, e) =>
            {
                
                    UITextView label = new UITextView(new System.Drawing.RectangleF(40, y, 200, 40));
                    //label.Placeholder = " Step " + i.ToString();
                    label.Layer.BorderWidth = 1f;
                    label.Layer.CornerRadius = 8;

                    TextFieldList.Add(label);
                    scrollView.AddSubview(label);

                    y = y + 60;
                    i++;
                    newButton.Center = new CoreGraphics.CGPoint(150, y + 20);


            };
        }


               

          
        

        /* partial void Ddf_TouchUpInside(UIButton sender)
        {
          string f = "";
        if (mm.Ingrediants != null)
        {
         foreach (string item in mm.Ingrediants)
        {
          f = f + item + "\n";
        }
        aass.Text = f;


          }
    }*/
        public List<UITextView> TextFieldList = new List<UITextView>();
        public int y = 100;
        int i = 1;

        /*

partial void UIButton172966_TouchUpInside(UIButton sender)
       {
           string combinedstring = "";
            foreach (UITextField item in TextFieldList)
           {
                if (item.Text !=null)
                {
                    combinedstring = combinedstring + item.Text+"\n";
                }

           }
            aass.Text = combinedstring;
            
    }

partial void NewButton_TouchUpInside(UIButton sender)
        {
            UITextField label = new UITextField(new System.Drawing.RectangleF(40, y, 100, 20));
            label.Placeholder = "Step " + i.ToString();
            TextFieldList.Add(label);
            scrollView.AddSubview(label);

            y = y + 30;
            i++;
            newButton.Center=new CoreGraphics.CGPoint(150, y + 20);

           
        }
*/
    }
}
