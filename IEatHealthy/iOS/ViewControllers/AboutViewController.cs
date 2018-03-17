using System;
using UIKit;
using Foundation;

namespace IEatHealthy.iOS
{
    public partial class AboutViewController : UIViewController
    {
        public AboutViewModel ViewModel { get; set; }
        public AboutViewController(IntPtr handle) : base(handle)
        {
            ViewModel = new AboutViewModel();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = ViewModel.Title;

               }
        public Foundation.NSUrl url;

        partial void UIButton1646_TouchUpInside(UIButton sender)
        {
            UIApplication.SharedApplication.OpenUrl(new NSUrl("http://ieathealthy.info/Home/About"));


        }
    }
}
