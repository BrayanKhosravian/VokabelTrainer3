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
            vm?.ConfigureViewModel();
        }
    }
}
