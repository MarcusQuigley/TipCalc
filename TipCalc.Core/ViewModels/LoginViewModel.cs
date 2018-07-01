using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TipCalc.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        private string _id;
        private IMvxAsyncCommand _loginCommand;
        private IMvxNavigationService _navigationService;

        public LoginViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public IMvxAsyncCommand LoginCommand
        {
          //  get => new MvxCommand(() => base.ShowViewModel<TipViewModel>(), CanExecute);
            get {
                if (_loginCommand == null)
                {
                    _loginCommand = new MvxAsyncCommand(() => _navigationService.Navigate<TipViewModel>(),CanExecute);
                }
                return _loginCommand;
        }
        }

        public string Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    base.RaisePropertyChanged(() => Id);
                    LoginCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public bool CanExecute()
        {
            return !string.IsNullOrEmpty(Id);
        }
    }
}
