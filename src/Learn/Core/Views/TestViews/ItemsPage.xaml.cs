using System.Collections.ObjectModel;
using Learn.Core.Views.Base;

namespace Learn.Core.Views.TestViews
{
    public partial class ItemsPage : ContentPageBase<ItemsViewModel>
    {
        public ObservableCollection<string> Items { get; set; }

        public ItemsPage()
        {
            InitializeComponent();
        }
    }
}
