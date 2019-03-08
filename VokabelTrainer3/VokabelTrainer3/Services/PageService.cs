using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VokabelTrainer3.Services
{
    class PageService : IPageService
    {
        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }

        public async Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
        {
            if(buttons?.Length < 0) throw new IndexOutOfRangeException();
            return await Application.Current.MainPage.DisplayActionSheet(title,cancel,destruction,buttons);
        }
    }
}
