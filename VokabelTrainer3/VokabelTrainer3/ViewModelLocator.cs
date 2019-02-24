using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Autofac;
using Autofac.Core;

namespace VokabelTrainer3
{
    static class ViewModelLocator
    {
        private static IContainer _container;

        public static void SetContainerProvider(IContainer container)
        {
            _container = container;
        }

        public static T ResolveWithParameter<T>(NamedParameter parameter) where T : class
        {
            return _container.Resolve<T>(parameter);
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        public static T ResolveWithParameters<T>(params Parameter[] parameters) where T : class
        {
            if (parameters.Length == 0) throw new ArgumentNullException();
            if (parameters == null) throw new ArgumentNullException();

            return _container.Resolve<T>(parameters[0]);

        }
    }
}
