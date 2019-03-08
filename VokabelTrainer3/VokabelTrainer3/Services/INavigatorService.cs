using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using VokabelTrainer3.ViewModels;

namespace VokabelTrainer3.Services
{
    public interface INavigatorService
    {
        Task PopAsync();
        Task PopToRootAsync();

        Task PushAsync<TViewModel>() 
            where TViewModel : BaseVM;

        Task PushWithParameterAsync<TViewModel>(NamedParameter parameter)
            where TViewModel : BaseVM;

        Task PushWithParametersAsync<TViewModel>(params Parameter[] parameters)
            where TViewModel : BaseVM;

    }
}
