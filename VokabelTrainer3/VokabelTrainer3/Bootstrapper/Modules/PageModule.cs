using Autofac;
using VokabelTrainer3.ViewModels;
using VokabelTrainer3.Views;

namespace VokabelTrainer3.Bootstrapper.Modules
{
    class PageModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WelcomePage>();
            builder.RegisterType<WelcomePageVM>();

            builder.RegisterType<ChapterSelectionLVPage>();
            builder.RegisterType<ChapterSelectionLVPageVM>();

            builder.RegisterType<QuizPage>();
            builder.RegisterType<QuizPageVM>();

            builder.RegisterType<DisplayVocabsLVPage>();
            builder.RegisterType<DisplayVocabsLVPageVM>();
        }
    }
}
