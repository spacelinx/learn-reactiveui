using Learn.Core.Models;

namespace Learn.Core.Settings.Base
{
    public interface ISettings
    {
        string BaseUrl { get; }

        double HeroHeight { get; }
        ScreenDimensions ScreenDimensions { get; }
    }
}