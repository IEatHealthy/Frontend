using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace IEatHealthy.iOS
{
    public partial class TimerViewController : UIViewController
    {
        NSTimer timer;
        bool isdone = false;
        public int MinuteCount = 0;
        public int HourCount = 0;
        public int SecondCount = 0;
        public TimerViewController(IntPtr handle) : base(handle)
        {
        }
       

partial void StartTimerButton_TouchUpInside(UIButton sender)
        {
            
            MinuteCount=Convert.ToInt32 (MinuteInputLabl.Text); 
            HourCount=Convert.ToInt32 (HourInputLabel.Text); 
            if(MinuteCount>0 || HourCount>0){
                HourLabel.Text = HourCount.ToString();
                MinuteLable.Text = MinuteCount.ToString();

                SecondLabel.Text = SecondCount.ToString();
                timer = NSTimer.CreateRepeatingScheduledTimer (TimeSpan.FromSeconds (1.0), delegate {
                    if (isdone) stoptimer();
                    timeraction();
                }); 
            } 
        }
        public void timeraction(){
            if (SecondCount > 0){ SecondCount--; }
            if (MinuteCount > 0 && SecondCount == 0) { MinuteCount--; SecondCount = 60; }
            if (HourCount > 0 && MinuteCount == 0) { HourCount--; MinuteCount = 60; }
            if(HourCount==0 && MinuteCount==0 && SecondCount==0){
                isdone = true;
            }
            HourLabel.Text = HourCount.ToString();
            MinuteLable.Text = MinuteCount.ToString();
            SecondLabel.Text = SecondCount.ToString();
                    }
        public void stoptimer(){
            timer.Invalidate();
        }
       


partial void StopTimerLabel_TouchUpInside(UIButton sender)
        {
            timer = null;
        }
    }
}
