using Learn.Core.Models;
using Learn.Core.Services.DeviceInfo;
using Xamarin.Forms;

namespace Learn.Core.Settings.Base
{
    public abstract class BaseSettings : ISettings
    {
        private double _heroHeight;
        private ScreenDimensions _screenDimensions;
        private IDeviceInfoService _deviceInfoService;

        public abstract string BaseUrl { get; }
        public object Code => "Hello";

        /// <summary>
        /// This uses the Acr.DeviceInfo to get screen dimensions.
        /// We are also using Xam.Plugins.DeviceInfo (which doesn't seem to contain device info for screen, but contains
        /// other properties required for crash reporting).
        /// We may want to rationalise plugins to use one or either device info in a future sprint.
        /// </summary>
        public ScreenDimensions ScreenDimensions
        {
            get
            {
                // can't create this object in a constructor as settings object
                // won't be created until after the Container.Build command is issued
                // It is likely that settings is created for the first time within the DI bootstrapper.
//                if (_deviceInfoService == null)
//                    _deviceInfoService = ((Startup.App)Application.Current).Container.Resolve<IDeviceInfoService>();

                if (_screenDimensions == null)
                    _screenDimensions = new ScreenDimensions();

                // only needs to be set once
                if (_screenDimensions.ScreenWidth.Equals(0.0d))
                    _screenDimensions.ScreenWidth = _deviceInfoService.ScreenWidth;

                if (_screenDimensions.ScreenHeight.Equals(0.0d))
                    _screenDimensions.ScreenHeight = _deviceInfoService.ScreenHeight;


                return _screenDimensions;
            }
        }

        public double HeroHeight
        {
            get
            {
                // only needs to be set once
                // however this can't be set in the basesettings constructure
                // as more than likely this will run at app startup before the device width is known
                if (_heroHeight.Equals(0.0d))
                    _heroHeight = Application.Current.MainPage.Width / 16 * 9;

                return _heroHeight;
            }
        }

    }
}
