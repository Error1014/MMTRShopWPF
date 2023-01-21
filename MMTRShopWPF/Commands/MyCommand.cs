﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MMTRShopWPF.Commands
{
    public abstract class MyCommand<TViewModel> : ICommand where TViewModel : class
    {
        protected TViewModel viewModel;
        public MyCommand(TViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public event EventHandler CanExecuteChanged;
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }
}
