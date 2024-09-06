using MVVMLib.Exceptions;

namespace MVVMLib
{
    public class ViewModelLocator : IViewModelLocator
    {
        private Dictionary<Type, Func<BaseViewModel>> _viewModelFactories = new();

        public void Register<TViewModel, TView>(Func<TViewModel> factory)
            where TViewModel : BaseViewModel
            where TView : class
        {
            if (_viewModelFactories[typeof(TView)] == null) _viewModelFactories[typeof(TView)] = factory;

            throw new AlreadyRegisteredException($"The mapping for view {typeof(TView)} already exists.");
        }

        public object Resolve(object view)
        {
            Type viewType = view.GetType();

            if (_viewModelFactories.ContainsKey(viewType))
            {
                return _viewModelFactories[viewType]();
            }

            throw new NoValidRegistationException($"There was no valid mapping for {viewType}.");
        }
    }
}
