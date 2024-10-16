using System.ComponentModel;
using MVVMLib.Data;

namespace MVVMLib.Navigation
{

    public class NavigationService : IsObservable
    {
        private ViewModel? _currentViewModel;
        public ViewModel? CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        private Stack<ViewModel> _forwardViewModels;

        private Stack<ViewModel> _backwardViewModels;

        private static IDictionary<Type, Func<NavigationService, ViewModel>> _viewModelFactories = new Dictionary<Type, Func<NavigationService, ViewModel>>();

        public NavigationService()
        {
            _forwardViewModels = new();
            _backwardViewModels = new();
            CurrentViewModel = null;
        }

        public static void RegisterViewModelFactory<TViewModel>(Func<NavigationService, TViewModel> viewModelFactory) where TViewModel : ViewModel
        {
            if (_viewModelFactories.ContainsKey(typeof(TViewModel))) return;

            _viewModelFactories.Add(typeof(TViewModel), viewModelFactory);
        }

        public void NavigateTo<TViewModel>() where TViewModel : ViewModel
        {
            _forwardViewModels.Clear();

            if (CurrentViewModel is not null)
            {
                _backwardViewModels.Push(CurrentViewModel);
            }

            var existingViewModel = _backwardViewModels.OfType<TViewModel>().FirstOrDefault();

            if (existingViewModel is not null)
            {
                CurrentViewModel = existingViewModel;
            }
            else
            {
                if (_viewModelFactories.TryGetValue(typeof(TViewModel), out var factory))
                {
                    CurrentViewModel = factory(this);
                }
                else
                {
                    throw new InvalidOperationException($"No factory registered for {typeof(TViewModel).Name}");
                }
            }
        }

        public void GoBack()
        {
            if (CanGoBack())
            {
                if (CurrentViewModel is not null)
                {
                    _forwardViewModels.Push(CurrentViewModel);
                }

                CurrentViewModel = _backwardViewModels.Pop();
            }
        }

        public bool CanGoBack() => _backwardViewModels.Any();

        public void GoForward()
        {
            if (CanGoForward())
            {
                if (CurrentViewModel is not null)
                {
                    _backwardViewModels.Push(CurrentViewModel);
                }

                CurrentViewModel = _forwardViewModels.Pop();
            }
        }

        public bool CanGoForward() => _forwardViewModels.Any();
    }
}
