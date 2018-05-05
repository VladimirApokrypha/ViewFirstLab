using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeModel;
using GalaSoft.MvvmLight.Command;

namespace EmployeeBuisnessLogic
{
    public class DeleteWindowViewModel : ViewModelBase
    {
        private string _name;
        private int _age;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                AddCommand.RaiseCanExecuteChanged();
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                AddCommand.RaiseCanExecuteChanged();
            }
        }

        public DeleteWindowViewModel()
        {
            AddCommand = new RelayCommand(Add, () => Age > 0 && Name != null);

        }

        public RelayCommand AddCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }

        public void Add()
        {
            ViewModelManager.Instance.ViewModelClose(this);
        }

    }
}
