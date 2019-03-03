using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VokabelTrainer3.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VokabelTrainer3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizPage : ContentPage
    {
        private readonly string _chapterPath;
        public QuizPage(string chapterPath)
        {
            InitializeComponent();

            _chapterPath = chapterPath;
        }

        public QuizPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            (BindingContext as QuizPageVM)?.ConfgureViewModel();
           
        }
    }
}