using System;
using System.Collections.Generic;
using System.Text;
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

            builder.RegisterType<ChapterSelectionListViewPage>();
            builder.RegisterType<ChapterSelectionListViewPageVM>();

            builder.RegisterType<VocabQuizPage>();
            builder.RegisterType<VocabQuizPageVM>();
        }
    }
}
