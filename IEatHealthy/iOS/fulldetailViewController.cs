using Foundation;
using System;
using UIKit;

namespace IEatHealthy.iOS
{
    public partial class FullDetailViewController : UIViewController
    {
        public FullDetailViewController(IntPtr handle) : base(handle)
        {
        }
       
        public Item mm = new Item { };
		public override void ViewDidLoad()
		{
            base.ViewDidLoad();
            lav.Text = mm.Text;
		}

        partial void Ddf_TouchUpInside(UIButton sender)
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
        }
    }
}
