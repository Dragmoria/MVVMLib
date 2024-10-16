using System.Windows.Input;
using MVVMLib.Commands;
using MVVMLib.Data;
using MVVMLib.Navigation;

namespace MVVMLib.UI.ViewModels;

public class SomeDumbViewModel : ViewModel
{
    public ICommand GoBackCommand { get; private set; }
    public ICommand GoForwardCommand { get; private set; }
    public ICommand NavigateCommand { get; private set; }

    private int _count = 0;

    public int Count
    {
        get => _count;
        set => SetProperty(ref _count, value);
    }

    public SomeDumbViewModel(NavigationService navigationService) : base(navigationService)
    {
        GoBackCommand = new RelayCommand(() => GoBack(navigationService), () => CanGoBack(navigationService));
        GoForwardCommand = new RelayCommand(() => GoForward(navigationService), () => CanGoForward(navigationService));
        NavigateCommand = new RelayCommand(() => Navigate(navigationService), () => CanNavigate(navigationService));
    }

    private bool CanGoBack(object parameter) => _navigationService.CanGoBack();

    private void GoBack(object parameter)
    {
        Count++;
        _navigationService.GoBack();
    }

    private bool CanGoForward(object parameter) => _navigationService.CanGoForward();
    private void GoForward(object parameter)
    {
        Count++;
        _navigationService.GoForward();
    }

    private bool CanNavigate(object parameter) => true;

    private void Navigate(object parameter)
    {
        Count++;
        _navigationService.NavigateTo<SomeViewModel>();
    }
}