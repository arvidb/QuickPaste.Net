using Autofac;
using Autofac.Core;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickPaste.Net.ViewModels;

namespace QuickPaste.Net
{
    public class Bootstrapper
    {
        private static Logger Logger => LogManager.GetCurrentClassLogger();

        private static ILifetimeScope _rootScope;

        /// <summary>
        /// instantiate with external builder
        /// Used by e.g. unit tests
        /// </summary>
        /// <param name="builder"></param>
        public Bootstrapper(ContainerBuilder builder)
        {
            _rootScope?.Dispose();
            _rootScope = builder.Build();
        }

        /// <summary>
        /// Create with default application builder
        /// </summary>
        public Bootstrapper()
        {
            Logger.Debug("Running Bootstrap");

            if (_rootScope == null)
            {
                Logger.Debug("Setting up IOC container");

                var builder = new ContainerBuilder();

                // Services
                builder.RegisterType<PasteItemService>().As<IPasteItemService>().SingleInstance();

                // View models
                builder.RegisterType<PropertiesViewModel>();
                builder.RegisterType<MainViewModel>();
                builder.RegisterType<TrayPopupViewModel>();

                _rootScope = builder.Build();
            }
            else
            {
                Logger.Error("Bootrapper already initialized");
            }
        }

        public static T Resolve<T>()
        {
            if (_rootScope == null)
            {
                throw new Exception("Bootstrapper hasn't been started!");
            }

            return _rootScope.Resolve<T>();
        }

        public static T Resolve<T>(Parameter[] parameters)
        {
            if (_rootScope == null)
            {
                throw new Exception("Bootstrapper hasn't been started!");
            }

            return _rootScope.Resolve<T>(parameters);
        }
    }
}
