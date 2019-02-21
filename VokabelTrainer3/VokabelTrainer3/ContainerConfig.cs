using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace VokabelTrainer3
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();


            // register

            return builder.Build();
        }
    }
}
