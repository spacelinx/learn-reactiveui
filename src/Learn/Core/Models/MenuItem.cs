using System;
using System.Threading.Tasks;
using ReactiveUI;

namespace Learn.Core.Models
{
    public class MenuItem : ReactiveObject
    {
        private string _title;
        private MenuItemType _menuItemType;
        private string _viewModelType;
        private bool _isEnabled;

        public string Title
        {
            get => _title;

            set => this.RaiseAndSetIfChanged(ref _title, value);
        }

        public MenuItemType MenuItemType
        {
            get => _menuItemType;

            set => this.RaiseAndSetIfChanged(ref _menuItemType, value);
        }

        public string ViewModelType
        {
            get => _viewModelType;

            set => this.RaiseAndSetIfChanged(ref _viewModelType, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;

            set => this.RaiseAndSetIfChanged(ref _isEnabled, value);
        }

        public Func<Task> AfterNavigationAction { get; set; }
    }
}