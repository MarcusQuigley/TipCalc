using MvvmCross.Wpf.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using System.Windows.Threading;
using MvvmCross.Wpf.Views;
using MvvmCross.Core.ViewModels;
namespace TipCalc.UI.Wpf
{
   public class Setup : MvxWpfSetup
    {
        public Setup(Dispatcher uiThreadDispatcher, IMvxViewPresenter presenter)
            :base(uiThreadDispatcher, presenter)
        {
            
        }

        protected override IMvxApplication CreateApp()
        {
            throw new NotImplementedException();
        }
    }
}
