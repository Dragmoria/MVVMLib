﻿using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MVVMLib.Navigation;

namespace MVVMLib.Data
{
    public abstract class ViewModel : IsObservable, INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> _allErrors = new();

        public bool HasErrors => _allErrors.Count != 0;

        public IEnumerable GetErrors(string? propertyName)
        {
            if (propertyName is not null && _allErrors.ContainsKey(propertyName)) return _allErrors[propertyName];

            return new List<string>();
        }

        public void AddError([CallerMemberName] string? propertyName = null, string errorMessage = "")
        {
            ArgumentNullException.ThrowIfNull(propertyName);

            if (!_allErrors.ContainsKey(propertyName)) _allErrors[propertyName] = new();

            _allErrors[propertyName].Add(errorMessage);
            ErrorsChanged?.Invoke(this, new(propertyName));
        }

        public void ClearErrors([CallerMemberName] string? propertyName = null)
        {
            ArgumentNullException.ThrowIfNull(propertyName);

            if (!_allErrors.ContainsKey(propertyName)) return;

            _allErrors.Remove(propertyName);
            ErrorsChanged?.Invoke(this, new(propertyName));
        }

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        protected NavigationService _navigationService;

        public ViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
