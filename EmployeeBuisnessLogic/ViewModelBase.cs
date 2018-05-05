using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBuisnessLogic
{
    public class ViewModelBase
    {
        public event EventHandler Closed;

        public bool IsClosed { get; set; }

        protected virtual bool OnClosing()
        {
            return true;
        }

        public void Close()
        {
            if (!IsClosed && OnClosing())
            {
                IsClosed = true;
                OnClosed();
            }
        }

        private void OnClosed()
        {
            //ViewModelManager.Instance.ViewModelClose(this);
            Closed?.Invoke(this, EventArgs.Empty);
        }
    }
}
