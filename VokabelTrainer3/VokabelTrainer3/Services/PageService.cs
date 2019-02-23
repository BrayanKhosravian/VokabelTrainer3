using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VokabelTrainer3.Interfaces;
using Xamarin.Forms;

namespace VokabelTrainer3.Services
{
    class PageService : IPageService
    {
        public async Task NavigationPushAsync(Page page)
        {
           await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task NavigationPopAsync()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }
    }
}
