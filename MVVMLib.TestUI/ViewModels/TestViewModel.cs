using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMLib.TestUI.ViewModels
{
    public class TestViewModel : BaseViewModel
    {
        private readonly NavigationService _navigationService;

        public TestViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateToSomeRandomViewCommand = new RelayCommand(NavigateToSomeRandomView, CanNavigateToSomeRandomView);
        }

        public ICommand NavigateToSomeRandomViewCommand { get; private set; }

        private void NavigateToSomeRandomView()
        {
            _navigationService.NavigateTo<SomeOtherTestViewModel>();
        }

        private bool CanNavigateToSomeRandomView()
        {
            return true;
        }
    }
}
