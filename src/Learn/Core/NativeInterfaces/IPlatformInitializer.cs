
using Splat;

namespace Learn.Core.NativeInterfaces
{
    public interface IPlatformInitializer
    {
        void RegisterTypes(IMutableDependencyResolver resolver);
    }
}
