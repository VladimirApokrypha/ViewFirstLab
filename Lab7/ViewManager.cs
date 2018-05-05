using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EmployeeBuisnessLogic;

namespace Lab7
{
    public class ViewManager
    {
        private static readonly Dictionary<Type, Type> Mapping
            = new Dictionary<Type, Type>()
            {
                {typeof(MainWindowViewModel), typeof(MainWindow)},
                {typeof(DeleteWindowViewModel), typeof(DeleteWindow)}
            };

        private static readonly Dictionary<ViewModelBase, Window> OpenViewModelMapping
            = new Dictionary<ViewModelBase, Window>();


        public static void ViewShow(ViewModelBase viewModel)
        {
            if (OpenViewModelMapping.ContainsKey(viewModel))
            {
                throw new ArgumentException("View model is open now");
            }

            var typeViewModel = viewModel.GetType();
            if (Mapping.ContainsKey(typeViewModel))
            {
                Type typeView = Mapping[typeViewModel];
                var window = (Window) Activator.CreateInstance(typeView);

                window.DataContext = viewModel;
                window.Show();

                OpenViewModelMapping.Add(viewModel, window);
            }
        }

        public static void ViewClose(ViewModelBase viewModel)
        {
            if (OpenViewModelMapping.ContainsKey(viewModel))
            {
                var window = OpenViewModelMapping[viewModel];
                window.Close();

                OpenViewModelMapping.Remove(viewModel);
            }
        }
    }
}
