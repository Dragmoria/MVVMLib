using MVVMLib.Data;
using MVVMLib.Navigation;

namespace MVVMLib.UI.ViewModels;

public class MainWindowViewModel : ViewModel
{
    public NavigationService NavigationService { get; set; }

    public MainWindowViewModel(NavigationService navigationService) : base(navigationService)
    {
        NavigationService = navigationService;
    }
}