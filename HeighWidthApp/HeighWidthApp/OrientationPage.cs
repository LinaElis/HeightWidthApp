using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using DeviceOrientation.Forms.Plugin.Abstractions;
using Xamarin;
using Xamarin.Forms;

namespace HeighWidthApp
{
    public class OrientationPage : BaseOrientationPage
    {
        private Label orientationLabel;

        public OrientationPage()
        {
            try
            {
                orientationLabel = new Label();
                orientationLabel.VerticalOptions = LayoutOptions.Center;
                orientationLabel.HorizontalOptions = LayoutOptions.Center;
                Content = orientationLabel;
            }
            catch (Exception exception)
            {

                Insights.Report(exception, new Dictionary<string, string> {
                {"Something went wrong with your label.", "foobar"}
                });
            }
        }

        //Gör samma sak som metoden nedan - OrientationChanged:

        //protected override void OnAppearing()
        //{
        //    MessagingCenter.Subscribe<DeviceOrientationChangeMessage>
        //        (this, DeviceOrientationChangeMessage.MessageId, (message) =>
        //        {
        //            ReconfigureUI(message.Orientation);
        //        });
        //    base.OnAppearing();
        //}

        //protected override void OnDisappearing()
        //{
        //    MessagingCenter.Unsubscribe<DeviceOrientationChangeMessage>(this, DeviceOrientationChangeMessage.MessageId);
        //    base.OnDisappearing();
        //}

        //private void ReconfigureUI(DeviceOrientations orientation)
        //{
        //    orientationLabel.Text = orientation.ToString();
        //}

        protected override void OrientationChanged(Orientations newOrientations)
        {
            if (newOrientations == Orientations.Landscape)
            {
                orientationLabel.Text = "Landscape";
            }
            else
            {
                orientationLabel.Text = "Portrait";
            }
        }
    }
}
