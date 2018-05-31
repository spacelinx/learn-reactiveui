using Autofac;

namespace Learn.Core.NativeInterfaces
{
    public interface IPlatformInitializer
    {
        void RegisterTypes(ContainerBuilder builder);
    }
}
