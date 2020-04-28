using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using LoginDemo.Views;
using Xamarin.Forms;

namespace LoginDemo.Models
{
    public class ChatListingModel : ChatListingObservableObject
    {
        public ObservableCollection<ChatDetail> Monkeys { get; set; }
        public string Intro { get; set; }
        public string Summary { get { return " There were " + Monkeys.Count + " monkeys"; } }

        public ChatListingModel()
        {
            Monkeys = new ObservableCollection<ChatDetail> {
                new ChatDetail {Name="Rahish", Message="Let's have a call in 10mins", MessageCount = "2", ReceivedStamp = "2m"},
                new ChatDetail {Name="Ankur", Message="see you soon", MessageCount = "10", ReceivedStamp = "yesterday"},
                new ChatDetail {Name="Inder", Message="Check mail please", MessageCount = "20", ReceivedStamp = "2d"},
                new ChatDetail {Name="Amrit", Message="Where are you", MessageCount = "1", ReceivedStamp = "1w"},
                new ChatDetail {Name="e", Message="Alright", MessageCount = "", ReceivedStamp = "6m"},
                new ChatDetail {Name="f", Message="fff", MessageCount = "7", ReceivedStamp = "4d"},
                new ChatDetail {Name="g", Message="ggg", MessageCount = "", ReceivedStamp = "6d"},
                new ChatDetail {Name="i", Message="iii", MessageCount = "", ReceivedStamp = "8w"},
                new ChatDetail {Name="j", Message="jjj", MessageCount = "", ReceivedStamp = "1m"},
                new ChatDetail {Name="k", Message="kkk", MessageCount = "9", ReceivedStamp = "5m"},
                new ChatDetail {Name="l", Message="lll", MessageCount = "9", ReceivedStamp = "8m"},
                new ChatDetail {Name="m", Message="mmm", MessageCount = "6", ReceivedStamp = "yesterday"},
                new ChatDetail {Name="n", Message="nnn", MessageCount = "", ReceivedStamp = "10m"},
                new ChatDetail {Name="o", Message="ooo", MessageCount = "8", ReceivedStamp = "yesterday"},
            };
            Intro = "Pinned";
        }

        //plus handler
        public Command PlusBtnCommand
        {
            get
            {
                return new Command(AddNewEntryAsync);
            }
        }

        async void AddNewEntryAsync()
        {
            var detailPage = new EnterDetailPage();
            //detailPage.BindingContext = e.SelectedItem as Contact;
            detailPage.PlusButtonEventHandler += HandlePlusButtonCompletion;
            await App.Current.MainPage.Navigation.PushModalAsync(detailPage);
            ////create new object
            //var cd = new ChatDetail { Name = "Banku", Message = "ooo", MessageCount = "20", ReceivedStamp = "yesterday" };
            //Monkeys.Add(cd);
            //Monkeys[2].Name = "Bandar";
            //OnChanged("Monkeys");
            //OnChanged("Name");
        }

        private void HandlePlusButtonCompletion(object sender, ChatDetail chatDtl)
        {
            Monkeys.Add(chatDtl);
        }
    }

    public class ChatDetail : EventArgs
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public string MessageCount { get; set; }
        public string ReceivedStamp { get; set; }
    }
}

public class ChatListingObservableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnChanged(string p)
    {
        var changed = PropertyChanged;
        if (changed == null)
            return;
        changed.Invoke(this, new PropertyChangedEventArgs(p));
    }
}