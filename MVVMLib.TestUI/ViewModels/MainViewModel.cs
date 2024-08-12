using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLib.TestUI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly NavigationService _navigationService;

        public BaseViewModel CurrentViewModel => _navigationService.CurrentViewModel;

        public MainViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigationService.CurrentViewModelChanged += () => OnPropertyChanged(nameof(CurrentViewModel));
        }

        public void NavigateTo<T>() where T : BaseViewModel
        {
            _navigationService.NavigateTo<T>();
        }
    }
}
