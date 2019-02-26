using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Autofac;
using VokabelTrainer3.Models;
using VokabelTrainer3.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VokabelTrainer3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChapterSelectionListViewPage : ContentPage
    {
        private readonly string _path;

        public ChapterSelectionListViewPage(string path)
        {
            InitializeComponent();

            _path = path;

            BindingContext = ViewModelLocator.Resolve<ChapterSelectionListViewPageVM>();
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            if (e.Item == null)
                return;

            ((ListView)sender).SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            (BindingContext as ChapterSelectionListViewPageVM)?.CreateChapters();
        }
    }
}
