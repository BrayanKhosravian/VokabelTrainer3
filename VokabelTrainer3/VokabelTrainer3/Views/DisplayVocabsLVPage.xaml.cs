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
