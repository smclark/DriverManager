using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using DriverManager.Models.Interfaces;
using DriverManager.Models.Interfaces.Messages;
using DriverManager.Models.Messages;
using Microsoft.Practices.Unity;

namespace DriverManager.Models
{
    [Export(typeof(IPartImportsSatisfiedNotification))]
    sealed class PluginBootstrapper : IPartImportsSatisfiedNotification
    {
        /// <summary>
        /// Kicks off Unity type registrations.
        /// </summary>
        public void OnImportsSatisfied()
        {
            // Unity container type registrations.
            // ---------------------------------------------------------------------------------------.
            BuildContainer();
            // ---------------------------------------------------------------------------------------.
        }

        private static void BuildContainer()
        {
            var unity = IoC.Get<IUnityContainer>();

            unity.RegisterType<IDriver, Driver>();
            unity.RegisterType<IAddress, Address>();
            unity.RegisterType<IVehicle, Vehicle>();
            unity.RegisterType<IDriverCreatedMessage, DriverCreatedMessage>(new InjectionConstructor(typeof(string)));
        }
    }
}
