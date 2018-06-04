using System;
using Learn.Core.Common.Helpers;
using Learn.Core.NativeInterfaces;
using Learn.Core.Services.Authentication;
using Learn.Core.Services.Navigation;
using Learn.Core.Settings;
using Learn.Core.Views.Login;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;
using ReactiveUI;
using Splat;
using Xamarin.Forms;

namespace Learn.Core.Startup
{
    public class AppBootstrapper : ReactiveObject, IScreen
    {
        private readonly IPlatformInitializer _platformInitializer;
        public RoutingState Router { get; protected set; }

        public AppBootstrapper(IPlatformInitializer platformInitializer)
        {
            _platformInitializer = platformInitializer;
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

        public void Boot()
        {
            try
            {

                Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));
                Locator.CurrentMutable.Register(() => new LoginView(), typeof(IViewFor<LoginViewModel>));
                Locator.CurrentMutable.Register(() => new LoginService(), typeof(ILoginService));

                StartAppCenter();

                Router = new RoutingState();

                // You must register This as IScreen to represent your app's main screen
                Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));

                Locator.CurrentMutable.Register<LoginService, ILoginService>();
                Locator.CurrentMutable.Register<LoginViewModel>();

                NavigationService.Create(Router);
                NavigationService.Navigation(typeof(LoginViewModel));

            }
            catch (Exception ex)
            {
                // log
                throw ex;
            }
        }
    }
}
