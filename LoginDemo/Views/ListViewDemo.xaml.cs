using System;
using System.Collections.Generic;
using LoginDemo.Models;
using Xamarin.Forms;

namespace LoginDemo.Views
{
    //class Vehicle
    //{
    //    public string Name { get; set; }
    //    public string message { get; set; }
    //    public string messageCount { get; set; }
    //    public string receivedStamp { get; set; }
    //}

    //class VehicleVM
    //{
    //    public List<Vehicle> Monkeys { get; set; }
    //    public List<String> Intro { get; set; }
    //    public string Summary { get { return " There were " + Monkeys.Count + " monkeys"; } }
    //}

    public partial class ListViewDemo : ContentPage
    {
        private ChatListingModel chatListingModel;
        public ListViewDemo()
        {
            chatListingModel = new ChatListingModel();
            InitializeComponent();
            BindingContext = chatListingModel;
        }
    }
}
