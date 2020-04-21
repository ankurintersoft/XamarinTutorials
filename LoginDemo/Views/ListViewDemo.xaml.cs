using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LoginDemo.Views
{
    class Vehicle
    {
        public string Name { get; set; }
        public string message { get; set; }
        public string messageCount { get; set; }
        public string receivedStamp { get; set; }
    }

    class VehicleVM
    {
        public List<Vehicle> Monkeys { get; set; }
        public List<String> Intro { get; set; }
        public string Summary { get { return " There were " + Monkeys.Count + " monkeys"; } }
    }

    public partial class ListViewDemo : ContentPage
    {
        public ListViewDemo()
        {
            InitializeComponent();
            var monkeys = new List<Vehicle> {
                new Vehicle {Name="Rahish", message="Let's have a call in 10mins", messageCount = "2", receivedStamp = "2m"},
                new Vehicle {Name="Ankur", message="see you soon", messageCount = "10", receivedStamp = "yesterday"},
                new Vehicle {Name="Inder", message="Check mail please", messageCount = "20", receivedStamp = "2d"},
                new Vehicle {Name="Amrit", message="Where are you", messageCount = "1", receivedStamp = "1w"},
                new Vehicle {Name="e", message="Alright", messageCount = "", receivedStamp = "6m"},
                new Vehicle {Name="f", message="fff", messageCount = "7", receivedStamp = "4d"},
                new Vehicle {Name="g", message="ggg", messageCount = "", receivedStamp = "6d"},
                new Vehicle {Name="i", message="iii", messageCount = "", receivedStamp = "8w"},
                new Vehicle {Name="j", message="jjj", messageCount = "", receivedStamp = "1m"},
                new Vehicle {Name="k", message="kkk", messageCount = "9", receivedStamp = "5m"},
                new Vehicle {Name="l", message="lll", messageCount = "9", receivedStamp = "8m"},
                new Vehicle {Name="m", message="mmm", messageCount = "6", receivedStamp = "yesterday"},
                new Vehicle {Name="n", message="nnn", messageCount = "", receivedStamp = "10m"},
                new Vehicle {Name="o", message="ooo", messageCount = "8", receivedStamp = "yesterday"},
            };

            var sectionDta = new List<string> { "Pinned", "Fav", "Others" };

            BindingContext = new VehicleVM { Monkeys = monkeys, Intro = sectionDta };
        }
    }
}
