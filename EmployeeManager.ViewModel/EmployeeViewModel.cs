using EmployeeManager.Common.DataProvider;
using EmployeeManager.Common.Model;
using EmployeeManager.ViewModel.Command;
using System;

namespace EmployeeManager.ViewModel
{
    public class EmployeeViewModel : ViewModelBase
    {
        private readonly Employee _employee;
        public IEmployeeDataProvider _employeeDataProvider { get; }

        public EmployeeViewModel(Employee employee, IEmployeeDataProvider employeeDataProvider)
        {
            _employee = employee;
            _employeeDataProvider = employeeDataProvider;
            SaveCommand = new DelegateCommand(Save, () => CanSave);
        }
        public DelegateCommand SaveCommand { get; }

        public string FirstName
        {
            get => _employee.FirstName;
            set
            {
                if (_employee.FirstName != value)
                {
                    _employee.FirstName = value;
                    RaisePropertyCahnged();
                    RaisePropertyCahnged(nameof(CanSave));
                    SaveCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public DateTimeOffset EntryDate
        {
            get => _employee.EntryDate;
            set
            {
                if (_employee.EntryDate != value)
                {
                    _employee.EntryDate = value;
                    RaisePropertyCahnged();
                }
            }
        }
        public DateTime EntryDateTime
        {
            get => _employee.EntryDate.DateTime;
            set
            {
                if (_employee.EntryDate != value)
                {
                    _employee.EntryDate = value;
                    RaisePropertyCahnged();
                }
            }
        }

        public int JobRoleId
        {
            get => _employee.JobRoleId;
            set
            {
                if (_employee.JobRoleId != value)
                {
                    _employee.JobRoleId = value;
                    RaisePropertyCahnged();
                }
            }
        }

        public bool IsCoffeeDrinker
        {
            get => _employee.IsCoffeeDrinker;
            set
            {
                if (_employee.IsCoffeeDrinker != value)
                {
                    _employee.IsCoffeeDrinker = value;
                    RaisePropertyCahnged();
                }
            }
        }

        public bool CanSave => !string.IsNullOrEmpty(FirstName);
        public void Save()
        {
            _employeeDataProvider.SaveEmployee(_employee);
        }
    }
}
