using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBuisnessLogic
{
    public class ViewModelManager
    {
        private ViewModelManager()
        {
        }

        private static ViewModelManager _instacne;

        public static ViewModelManager Instance
        {
            get => _instacne ?? (_instacne = new ViewModelManager());
        }


        public event EventHandler<ViewModelShowEventArgs> ViewModelShowEvent;

        public void ViewModelShow(ViewModelBase viewModel)
        {
            OnViewModelShowEvent(viewModel);
        }

        private void OnViewModelShowEvent(ViewModelBase viewModel)
            => ViewModelShowEvent?.Invoke(this, new ViewModelShowEventArgs(viewModel));


        public event EventHandler<ViewModelCloseEventArgs> ViewModelCloseEvent;

        public void ViewModelClose(ViewModelBase viewModel)
        {
            OnViewModelCloseEvent(viewModel);
        }

        private void OnViewModelCloseEvent(ViewModelBase viewModel)
            => ViewModelCloseEvent?.Invoke(this, new ViewModelCloseEventArgs(viewModel));
    }



    public class ViewModelShowEventArgs : EventArgs
    {
        public ViewModelBase ViewModel { get; }

        public ViewModelShowEventArgs(ViewModelBase viewModel)
        {
            ViewModel = viewModel;
        }
    }

    public class ViewModelCloseEventArgs : EventArgs
    {
        public ViewModelBase ViewModel { get; }

        public ViewModelCloseEventArgs(ViewModelBase viewModel)
        {
            ViewModel = viewModel;
        }
    }
}
