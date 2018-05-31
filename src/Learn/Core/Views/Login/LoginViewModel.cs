using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reactive.Disposables;
using System.Text.RegularExpressions;
using Learn.Core.Views.Base;
using ReactiveUI;
using PropertyChangingEventArgs = ReactiveUI.PropertyChangingEventArgs;
using PropertyChangingEventHandler = ReactiveUI.PropertyChangingEventHandler;

namespace Learn.Core.Views.Login
{
    public class LoginViewModel : ViewModelBase
    {
        ILoginService _loginService;

        private string _userName;
        public string UserName
        {
            get => _userName;
            //Notify when property user name changes
            set => this.RaiseAndSetIfChanged(ref _userName, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        /// <summary>
        /// This is an Oaph Observable propperty helper, 
        /// Which is used to determine whether a subsequent action
        /// Could be performed or not depending on its value
        /// This condition is calculated every time its value changes.
        /// </summary>
        readonly ObservableAsPropertyHelper<bool> _validLogin;
        public bool ValidLogin => _validLogin?.Value ?? false;

        public ReactiveCommand LoginCommand { get; private set; }
        
        public LoginViewModel(ILoginService loginService, IScreen hostScreen = null) : base(hostScreen)
        {
            _loginService = loginService;

            //when the vm is activated bind the properties
            // this.WhenActivated(OnActivated);
            this.WhenActivated(d =>
            {
                Debug.WriteLine("SubView activated.");

                d(Disposable.Create(() =>
                {
                    Debug.WriteLine("SubView deactivated.");
                }));

            });

            this.WhenAnyValue(x => x.UserName, x => x.Password,
                (email, password) =>
                (
                    ///Validate the password
                    !string.IsNullOrEmpty(password) && password.Length > 5
                )
                &&
                (
                    ///Validate teh email.
                    !string.IsNullOrEmpty(email)
                            &&
                     Regex.Matches(email, "^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$").Count == 1
                ))
                .ToProperty(this, v => v.ValidLogin, out _validLogin);

            LoginCommand = ReactiveCommand.CreateFromTask(async () =>
            {

                var lg = await loginService.LoginAsync(_userName, _password);
                if (lg)
                {
                    HostScreen.Router
                                .Navigate
                                .Execute(new ItemsViewModel())
                                .Subscribe();
                }
            }, this.WhenAnyValue(x => x.ValidLogin, x => x.ValidLogin, (validLogin, valid) => ValidLogin && valid));

        }


    }

    public class ItemsViewModel : IRoutableViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
        public void RaisePropertyChanging(PropertyChangingEventArgs args)
        {
            throw new NotImplementedException();
        }

        public void RaisePropertyChanged(PropertyChangedEventArgs args)
        {
            throw new NotImplementedException();
        }

        public string UrlPathSegment { get; }
        public IScreen HostScreen { get; }
    }
}
