using System;
using Autofac;
using ReactiveUI;
using Splat;

namespace Learn.Core.Services.Navigation
{
    public static class NavigationService
    {
        private static IContainer _container;
        private static RoutingState _router;

        public static void Create(IContainer container, RoutingState router)
        {
            _container = container;
            _router = router;
        }

        public static void Navigation(Type viewModel)
        {
            var obj = _container.Resolve(viewModel);
            var view = (IRoutableViewModel)obj;

            _router
                .NavigateAndReset
                .Execute(view)
                .Subscribe();
        }
        public static void Navigation<T>(Type viewModel, T parameter)
        {
            var view = (IRoutableViewModel)Locator.CurrentMutable.GetService(viewModel);

            _router
                .NavigateAndReset
                .Execute(view)
                .Subscribe();
        }
    }
}