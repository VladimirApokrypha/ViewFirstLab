using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EmployeeBuisnessLogic;

namespace Lab7
{
    public class ViewBase : Window
    {
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (!((ViewModelBase)DataContext).IsClosed)
            {
                e.Cancel = true;
                //Dispatcher.BeginInvoke(new Action(() => ((ViewModelBase)DataContext).Close()));
                ((ViewModelBase)DataContext).Close();
            }
        }
    }
}
