using Learn.Core.Settings.Base;

namespace Learn.Core.Settings
{
    public static class SettingsManager
    {
        public static ISettings Get()
        {
#if DEBUG_MOCKS || DEBUG_MOCKS_IPA
           return new MockSettings();
#elif DEBUG
             return new AzureSettingsDev();
#else
             return new AzureSettingsProd();
#endif
        }
    }
}
