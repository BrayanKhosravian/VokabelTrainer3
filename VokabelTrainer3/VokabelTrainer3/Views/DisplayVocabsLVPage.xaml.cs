using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using VokabelTrainer3.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VokabelTrainer3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisplayVocabsLVPage : ContentPage
    {
        public DisplayVocabsLVPage()
        {
            InitializeComponent();
        }

        private void MyListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            MyListView.SelectedItem = null;
            return;
        }
    }
}
