using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace HeighWidthApp
{
    public class BaseOrientationPage : ContentPage
    {

        protected enum Orientations
        {
            Portrait,
            Landscape
        }

        private double _oldWidth, _oldHeight;

        protected virtual void OrientationChanged(Orientations newOrientation) { }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width != _oldWidth || height != _oldHeight)
            {
                _oldWidth = width;
                _oldHeight = height;
                OrientationChanged(width > height ? Orientations.Landscape : Orientations.Portrait);
            }
        }
    }
}
