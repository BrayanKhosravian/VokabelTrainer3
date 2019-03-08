using Autofac;
using VokabelTrainer3.Services;

namespace VokabelTrainer3.Bootstrapper.Modules
{
    class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PageService>().As<IPageService>().SingleInstance();
            builder.RegisterType<VocabularyParserService>().As<IVocabularyParserService>();

            builder.RegisterType<NavigatorService>().As<INavigatorService>().SingleInstance();
            builder.Register(componentContext => App.Current.MainPage.Navigation);
        }
    }
}
