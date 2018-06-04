using System;
using System.ComponentModel;
using ReactiveUI;
using Splat;

namespace Learn.Core.Services.Navigation
{
    public static class NavigationService
    {
        private static RoutingState _router;

        public static void Create(RoutingState router)
        {
            _router = router;
        }

        public static void Navigation(Type type)
        {
            var viewModel = (IRoutableViewModel)Locator.Current.GetService(type);

            _router
                .NavigateAndReset
                .Execute(viewModel)
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