﻿using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
 
using MvvmCross.Wpf.Views.Presenters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TipCalc.UI.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        bool _setupComplete;

        void DoSetup()
        {
            var presenter = new MvxWpfViewPresenter(MainWindow);

            var setup = new Setup(this.Dispatcher, presenter);
            setup.Initialize();

            var start = Mvx.Resolve<IMvxAppStart>();
            start.Start();

            _setupComplete = true;
        }

        protected override void OnActivated(EventArgs e)
        {
            if (!_setupComplete)
            {
                DoSetup();
            }
            base.OnActivated(e);
        }

    }

}
