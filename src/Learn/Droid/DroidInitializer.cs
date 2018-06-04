using Learn.Core.NativeInterfaces;
using Learn.Core.Services.NativeInterfaces;
using Learn.Droid.Services;
using Splat;

namespace Learn.Droid
{
    public class DroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IMutableDependencyResolver resolver)
        {
            resolver.Register(() => new ToastService(), typeof(IToastService));
        }
    }
}