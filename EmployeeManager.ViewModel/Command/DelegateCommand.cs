﻿using System;
using System.Windows.Input;

namespace EmployeeManager.ViewModel.Command
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _execute;
        public Func<bool> _canExecute { get; }

        public DelegateCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null
                 ? true
                 : _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
}