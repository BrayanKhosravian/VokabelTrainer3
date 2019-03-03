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
    public partial class ChapterSelectionLVPage : ContentPage
    {

        public ChapterSelectionLVPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var vm = (BindingContext as ChapterSelectionLVPageVM);
            vm?.CreateData();
            vm?.CreateChapters();
        }
    }
}
