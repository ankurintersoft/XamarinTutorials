using System;
using System.Collections.Generic;
using LoginDemo.Models;
using Xamarin.Forms;

namespace LoginDemo.Views
{
    public partial class EnterDetailPage : ContentPage
    {
        public event EventHandler<ChatDetail> PlusButtonEventHandler;
        //public event EventHandler PlusButtonEventHandler;

        public EnterDetailPage()
        {
            InitializeComponent();
        }

        async void OnDismissButtonClicked(object sender, EventArgs args)
        {
            Console.WriteLine(" name " + nameField.Text + " message " + messageField.Text + " count " + countField.Text);
            var cd = new ChatDetail { Name = nameField.Text, Message = messageField.Text, MessageCount = countField.Text, ReceivedStamp = "yesterday" };
            //Monkeys.Add(cd);
            if (PlusButtonEventHandler != null)
            {
                PlusButtonEventHandler(this, cd);
            }

            await Navigation.PopModalAsync();
        }
    }
}
