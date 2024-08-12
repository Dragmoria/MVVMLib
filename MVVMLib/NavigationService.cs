namespace MVVMLib
{
    public class NavigationService
    {
        public BaseViewModel CurrentViewModel { get; private set; }

        private readonly IViewModelFactory _viewModelFactory;

        public NavigationService(IViewModelFactory viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public void NavigateTo<TViewModel>() where TViewModel : BaseViewModel
        {
            CurrentViewModel = _viewModelFactory.CreateViewModel<TViewModel>();
            CurrentViewModelChanged?.Invoke();
        }

        public event Action CurrentViewModelChanged;
    }
}
