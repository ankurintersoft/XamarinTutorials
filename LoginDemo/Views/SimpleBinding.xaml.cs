using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LoginDemo
{
    public partial class SimpleBinding : ContentPage
    {
        public SimpleBinding()
        {
            InitializeComponent();

            //CODE BINDING, Binding can also be done like this if we are not binding in design file
            //label.BindingContext = slider;
            //label.SetBinding(Label.RotationProperty, "Value");
        }
    }
}
