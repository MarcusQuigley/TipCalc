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

        public ICommand LoginCommand
        {
            get => new MvxCommand(() => base.ShowViewModel<TipViewModel>());
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
                 
                }
            }
        }
    }
}
