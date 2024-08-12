using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMLib.TestUI.ViewModels
{
    public class SomeOtherTestViewModel : BaseViewModel
    {
        private readonly NavigationService _navigationService;

        public SomeOtherTestViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateToAnotherViewCommand = new RelayCommand(NavigateToAnotherView, CanNavigateToAnotherView);
        }

        public ICommand NavigateToAnotherViewCommand { get; private set; }

        private void NavigateToAnotherView()
        {
            _navigationService.NavigateTo<TestViewModel>();
        }

        private bool CanNavigateToAnotherView()
        {
            return true;
        }
    }
}
