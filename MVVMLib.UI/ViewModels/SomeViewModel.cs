using System.Collections.ObjectModel;
using MVVMLib.Data;
using MVVMLib.Navigation;
using System.Windows.Input;
using MVVMLib.Commands;
using MVVMLib.UI.Models;

namespace MVVMLib.UI.ViewModels;

public class SomeViewModel : ViewModel
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

    private string _title;

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    private string _filterText;

    public string FilterText
    {
        get => _filterText;
        set
        {
            SetProperty(ref _filterText, value);
            OnPropertyChanged(nameof(UserList));
        }
    }

    private ObservableCollection<User> _list;

    public ObservableCollection<User> UserList
    {
        get => new(_list.Where(user => user.ToString().Replace(" ", "").Contains(FilterText.Replace(" ", ""), StringComparison.OrdinalIgnoreCase)));
        set => SetProperty(ref _list, value);
    }

    public SomeViewModel(NavigationService navigationService) : base(navigationService)
    {
        GoBackCommand = new RelayCommand(() => GoBack(navigationService), () => CanGoBack(navigationService));
        GoForwardCommand = new RelayCommand(() => GoForward(navigationService), () => CanGoForward(navigationService));
        NavigateCommand = new RelayCommand(() => Navigate(navigationService), () => CanNavigate(navigationService));


        Title = "Title text";
        FilterText = string.Empty;
        UserList = new ObservableCollection<User>
        {
            new User("John", "Doe"),
            new User("Jane", "Smith"),
            new User("Jake", "Johnson"),
            new User("Bob", "Reef"),
            new User("Je", "Moeder")
        };
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
        _navigationService.NavigateTo<SomeDumbViewModel>();
    }
}