using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VokabelTrainer3.Interfaces
{
    public interface IPageService
    {

        Task DisplayAlert(string title, string message, string cancel);
        Task<bool> DisplayAlert(string title, string message, string accept, string cancel);

        /// <summary>
        /// Some parametes can be null when u dont want them to be active or displayed
        /// </summary>
        /// <param name="title"> cannot be null</param>
        /// <param name="cancel"> can be a nullable type</param>
        /// <param name="destruction">can be a nullable type</param>
        /// <param name="buttons"> cannot be null</param>
        /// <returns></returns>
        Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons);
    }
}
