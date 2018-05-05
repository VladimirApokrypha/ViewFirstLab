using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.Remoting.Channels;
using EmployeeModel;
using GalaSoft.MvvmLight.Command;

namespace EmployeeBuisnessLogic
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Employee _selectEmployee;

        public ObservableCollection<Employee> Employees { get; set; } 
             = new ObservableCollection<Employee>
            {
                new Employee { Name = "Vladimir", Age = 18 },
                new Employee { Name = "Alexandr", Age = 68 },
                new Employee { Name = "Dmitry", Age = 6 }
            };

        public Employee SelectEmployee
        {
            get => _selectEmployee;
            set
            {
                _selectEmployee = value;
                DeleteCommand.RaiseCanExecuteChanged();
                ChangeCommand.RaiseCanExecuteChanged();
            }
        }

        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand(Add, true);
            DeleteCommand = new RelayCommand(Delete, () => SelectEmployee != null);
            DeleteAllCommand = new RelayCommand(DeleteAll, true);
            DeleteOldCommand = new RelayCommand(DeleteAll, true);
            ChangeCommand = new RelayCommand(Change, () => SelectEmployee != null);
        }

        public RelayCommand AddCommand { get; set;}
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand DeleteAllCommand { get; set; }
        public RelayCommand DeleteOldCommand { get; set; }
        public RelayCommand ChangeCommand { get; set; }


        public void Add()
        {
            var deleteDialogWindow = new DeleteWindowViewModel();
            deleteDialogWindow.Closed += (sender, args) =>
            {
                Employee newEmp = new Employee()
                    {Name = deleteDialogWindow.Name, Age = deleteDialogWindow.Age};
                Employees.Add(newEmp);
            };
            ViewModelManager.Instance.ViewModelShow(new DeleteWindowViewModel());
        }

        public void Delete()
        {
            Employees.Remove(SelectEmployee);
        }

        public void DeleteAll()
        {
            Employees.Clear();
        }

        public void DeleteOld()
        {
            for (int i = 0; i < Employees.Count; i++)
            {
                if (Employees[i].Age > 60)
                { i--; Employees.RemoveAt(i); }
            }
        }

        public void Change()
        {

        }
    }
}
