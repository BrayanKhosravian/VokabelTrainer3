﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VokabelTrainer3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChapterSelectionListViewPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public ChapterSelectionListViewPage()
        {
            InitializeComponent();

            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
