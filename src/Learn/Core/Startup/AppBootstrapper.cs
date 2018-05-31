using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using Autofac;
using AutoMapper;
using Learn.Core.Common.Api.v1;
using Learn.Core.Common.Infrastructure;
using Learn.Core.NativeInterfaces;
using Learn.Core.Services.Authentication;
using Learn.Core.Services.Navigation;
using Learn.Core.Settings;
using Learn.Core.Settings.Base;
using Learn.Core.Views.Login;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;
using ReactiveUI;
using ReactiveUI.Autofac;
using Splat;
using Xamarin.Forms;

namespace Learn.Core.Startup
{
    public class AppBootstrapper : ReactiveObject, IScreen
    {
        private readonly IPlatformInitializer _platformInitializer;
        private readonly ContainerBuilder _containerBuilder;
        public RoutingState Router { get; protected set; }

        public AppBootstrapper(IPlatformInitializer platformInitializer)
        {
            _platformInitializer = platformInitializer;
            _containerBuilder = new ContainerBuilder();
        }

        private void StartAppCenter()
        {
            var appCenterAppIdIos = AppSettings.DefaultMobileCenterAnalyticsIos;
            var appCenterAppIdAndroid = AppSettings.DefaultMobileCenterAnalyticsAndroid;

            AppCenter.Start($"ios={appCenterAppIdIos};" +
                            $"android={appCenterAppIdAndroid};", typeof(Analytics), typeof(Crashes), typeof(Distribute));

        }

        public Page CreateMainPage()
        {
            // NB: This returns the opening page that the platform-specific
            // boilerplate code will look for. It will know to find us because
            // we've registered our AppBootstrappScreen.
            return new ReactiveUI.XamForms.RoutedViewHost();
        }

        public IContainer Boot()
        {
            try
            {
                var builder = new ContainerBuilder();

                var assembly = Assembly.GetExecutingAssembly();

                builder.RegisterAssemblyTypes(assembly)
                    .Where(t => typeof(IAutoMapperConfiguration).IsAssignableFrom(t))
                    .InstancePerLifetimeScope().AsImplementedInterfaces()
                    .AsImplementedInterfaces();


                var container = builder.Build();

                var automappers = container.Resolve<IEnumerable<IAutoMapperConfiguration>>();

                var config = new MapperConfiguration(cfg =>
                {
                    foreach (var instance in automappers)
                    {
                        var automapperConfig = instance;
                        automapperConfig?.ConfigureAutomapper(cfg);
                    }
                });

                var mapper = config.CreateMapper();

                RegisterCommonServices(mapper);

                // register the native types
                _platformInitializer.RegisterTypes(_containerBuilder);

                // register the views and view models
                _containerBuilder.RegisterViews(assembly);
                _containerBuilder.RegisterViewModels(assembly);
                _containerBuilder.RegisterScreen(assembly);

                _containerBuilder.RegisterType<LoginView>().As<IViewFor<LoginViewModel>>();

                var container1 = _containerBuilder.Build();
                RxAppAutofacExtension.UseAutofacDependencyResolver(container1);

                StartAppCenter();

                Router = new RoutingState();

                // You must register This as IScreen to represent your app's main screen
                Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));

                NavigationService.Create(container1, Router);
                NavigationService.Navigation(typeof(LoginViewModel));

                return container1;
            }
            catch (Exception ex)
            {
                // log
                throw ex;
            }
        }

        private void RegisterCommonServices(IMapper mapper)
        {

            var settings = SettingsManager.Get();
            _containerBuilder.RegisterType<LoginService>().As<ILoginService>();
            _containerBuilder.RegisterInstance(settings).As<ISettings>();

            _containerBuilder.RegisterInstance(new HttpClient());

            _containerBuilder.RegisterInstance(mapper).As<IMapper>();

            var mockApi = new MobileApiMock(settings, mapper);
            _containerBuilder.RegisterInstance(mockApi).As<IMobileApi>();
        }
    }
}
