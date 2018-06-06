using System.Reactive.Disposables;
using Learn.Core.Views.Base;
using ReactiveUI;

namespace Learn.Core.Views.Login
{
	public partial class LoginView : ContentPageBase<LoginViewModel>
	{

	    protected readonly CompositeDisposable SubscriptionDisposables = new CompositeDisposable();
        public LoginView()
		{
			InitializeComponent ();

		    this.WhenActivated(disposables =>
		    {
		        this.OneWayBind(ViewModel, x => x.UserName, x => x.Email.Text).DisposeWith(SubscriptionDisposables);
		        this.OneWayBind(ViewModel, x => x.Password, x => x.Password.Text, x => x).DisposeWith(SubscriptionDisposables);
		    });

        }
    }
}