using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VokabelTrainer3.Interfaces
{
    interface IPageService
    {
        Task NavigationPushAsync(Page page);
        Task NavigationPopAsync();

        Task DisplayAlert(string title, string message, string cancel);
        Task<bool> DisplayAlert(string title, string message, string accept, string cancel);
    }
}
