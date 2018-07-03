using MvvmCross.Wpf.Views;
using MvvmCross.Wpf.Views.Presenters;
using MvvmCross.Wpf.Platform;
using MvvmCross.Core.ViewModels;
using System.Windows.Threading;


namespace TipCalc.UI.Wpf
{
   public class Setup : MvxWpfSetup
    {
        public Setup(Dispatcher uiThreadDispatcher, IMvxWpfViewPresenter presenter)
            :base(uiThreadDispatcher, presenter)
        {
            
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
    }
}
