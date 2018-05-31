using Plugin.DeviceInfo;

namespace Learn.Core.Services.DeviceInfo
{
    public class DeviceInfoService : IDeviceInfoService
    {
        public double ScreenWidth => CrossDevice.Device.ScreenWidth;

        public double ScreenHeight => CrossDevice.Device.ScreenHeight;
    }
}
