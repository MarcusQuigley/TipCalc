using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using TipCalc.Core.Services;

namespace TipCalc.Core.ViewModels
{
   public class TipViewModel : MvxViewModel
    {
        readonly ICalculationService _service;
        double _subTotal;
        double _tip;
        int _generosity;

        public TipViewModel(ICalculationService service)
        {
            _service = service;
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
