using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Caliburn.Micro;
using DriverManager.DataProviders;
using DriverManager.DataProviders.Interfaces;
using DriverManager.Models;
using DriverManager.Models.Interfaces;
using DriverManager.ViewModels;
using DriverManager.ViewModels.Interfaces;
using Microsoft.Practices.Unity;

namespace DriverManager
{
    class ApplicationBootstrapper : Bootstrapper<IMainShellViewModel>
    {
        private IUnityContainer _unity;

        /// <summary>
        /// Override to configure the framework and setup your IoC container.
        /// </summary>
        protected override void Configure()
        {
            _unity = BuildContainer();
        }

        /// <summary>
        /// Gets the instance of the type that is passed into the Method.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="Exception"><c>Exception</c>.</exception>
        protected override object GetInstance(Type serviceType, string key)
        {
            var result = _unity.Resolve(serviceType, key);

            if (result == null)
                throw new Exception(string.Format("Could not locate any instances of contract {0}", serviceType));

            return result;
        }

        /// <summary>
        /// Gets all instances of a particular type
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _unity.ResolveAll(serviceType);
        }

        protected override void BuildUp(object instance)
        {
            _unity.BuildUp(instance.GetType(), instance);
        }

        private static IUnityContainer BuildContainer()
        {
            IUnityContainer result = new UnityContainer();

            result.RegisterInstance<IWindowManager>(new WindowManager());
            result.RegisterInstance<IEventAggregator>(new EventAggregator());

            result.RegisterType<IDriver, Driver>();
            result.RegisterType<IAddress, Address>();
            result.RegisterType<IVehicle, Vehicle>();

            result.RegisterType<Func<IDriver>>(
                new InjectionFactory((i => new Func<IDriver>(() => result.Resolve<IDriver>()))));

            result.RegisterType<IMainShellViewModel, MainShellViewModel>
                (new InjectionConstructor(typeof(IDriverListViewModel), typeof(IAddDriverViewModel), typeof(IEventAggregator)));

            //Driver List Registrations
            result.RegisterType<IDriverDataProvider, DriverDataProvider>();

            result.RegisterType<IDriverModel, DriverModel>(new InjectionConstructor(typeof(IDriverDataProvider)));

            result.RegisterType<IDriverListViewModel, DriverListViewModel>
                (new InjectionConstructor(typeof(IDriverModel)));

            result.RegisterType<IAddDriverViewModel, AddDriverViewModel>
                (new InjectionConstructor(typeof(Func<IDriver>),typeof(IDriverModel), typeof(IEventAggregator)));

            return BuildContainer(result);
        }

        public static IUnityContainer BuildContainer(IUnityContainer container)
        {
            return container;
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            var assemblies = new List<Assembly>();
            assemblies.Add(Assembly.GetEntryAssembly());
            assemblies.Add(Assembly.LoadFrom("DriverManager.Views.dll"));
            assemblies.Add(Assembly.LoadFrom("DriverManager.ViewModels.dll"));
            assemblies.Add(Assembly.LoadFrom("DriverManager.Models.dll"));

            var referencedAssemblies = assemblies[0].GetReferencedAssemblies();

            assemblies.AddRange(referencedAssemblies.Select(Assembly.Load));

            AssemblySource.Instance.AddRange(assemblies);

            return base.SelectAssemblies();
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            ViewLocator.NameTransformer.AddRule
                (
                @"(?<nsbefore>([A-Za-z_]\w*\.)*)(?<nsvm>ViewerModels\.)(?<nsafter>([A-Za-z_]\w*\.)*)(?<basename>[A-Za-z_]\w*)(?<suffix>ViewModel$)",
                @"${nsbefore}Viewer.${nsafter}${basename}View",
                @"([A-Za-z_]\w*\.)*ViewerModels\.([A-Za-z_]\w*\.)*[A-Za-z_]\w*ViewModel$"
                );

            ViewModelLocator.NameTransformer.AddRule
               (
                    @"(?<nsbefore>([A-Za-z_]\w*\.)*)(?<nsview>Viewer\.)(?<nsafter>([A-Za-z_]\w*\.)*)(?<basename>[A-Za-z_]\w*)(?<suffix>View$)",
                    @"${nsbefore}ViewerModels.${nsafter}${basename}ViewModel",
                    @"([A-Za-z_]\w*\.)*Viewer\.([A-Za-z_]\w*\.)*[A-Za-z_]\w*View$"
               );

            base.OnStartup(sender, e);
        }
    }

}
