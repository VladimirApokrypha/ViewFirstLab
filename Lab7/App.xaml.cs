using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using EmployeeBuisnessLogic;

namespace Lab7
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ViewModelManager.Instance.ViewModelShowEvent
                += Instance_ViewModelShowEvent;
            ViewModelManager.Instance.ViewModelCloseEvent
                += Instance_ViewModelCloseEvent;

            var mainWindowViewModel = new MainWindowViewModel();
            ViewModelManager.Instance.ViewModelShow(mainWindowViewModel);
        }

        private void Instance_ViewModelShowEvent(object sender, ViewModelShowEventArgs viewModel)
        {
            Dispatcher.BeginInvoke(new Action(() => ViewManager.ViewShow(viewModel.ViewModel)));
        }

        private void Instance_ViewModelCloseEvent(object sender, ViewModelCloseEventArgs viewModel)
        {
            Dispatcher.BeginInvoke(new Action(() => ViewManager.ViewClose(viewModel.ViewModel)));
        }
    }
}
