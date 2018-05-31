using Autofac;
using Learn.Core.NativeInterfaces;
using Learn.Core.Services.NativeInterfaces;
using Learn.Droid.Services;

namespace Learn.Droid
{
    public class DroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<ToastService>().As<IToastService>();
        }
    }
}