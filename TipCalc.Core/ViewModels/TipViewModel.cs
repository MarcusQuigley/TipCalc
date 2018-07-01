using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TipCalc.Core.Services;

namespace TipCalc.Core.ViewModels
{
   public class TipViewModel : MvxViewModel
    {
        readonly ICalculationService _service;
        double _subTotal;
        double _tip;
        int _generosity;
        IMvxNavigationService _navigationService;
        IMvxAsyncCommand _finishCommand;
        public TipViewModel(ICalculationService service, IMvxNavigationService navigationService)
        {
            _service = service;
            _navigationService=  navigationService;
        }

        public double SubTotal
        {
            get => _subTotal;
            set
            {
                _subTotal = value;
                base.RaisePropertyChanged(() => SubTotal);
                Recalculate();
            }
        }

        public int Generosity
        {
            get => _generosity;
            set
            {
                _generosity = value;
                base.RaisePropertyChanged(() => Generosity);
                Recalculate();
            }
        }

        public double Tip
        {
            get => _tip;
            private set
            {
                _tip = value;
                base.RaisePropertyChanged(() => Tip);
             }
        }

        public IMvxAsyncCommand FinishCommand
        {
            get {
                if (_finishCommand == null)
                {
                    _finishCommand = new MvxAsyncCommand(() => _navigationService.Navigate<SummaryViewModel>());
                }
                return _finishCommand;
            }
            //get => new MvxCommand(() => ShowViewModel<SummaryViewModel>());
         }

        public override void Start()
        {
            _subTotal = 100;
            _generosity = 10;
            Recalculate();
            base.Start();
        }

        void Recalculate()
        {
            Tip = _service.TipAmount(SubTotal, Generosity);
        }
    }
}
