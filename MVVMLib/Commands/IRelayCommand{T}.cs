using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMLib.Commands
{
    internal interface IRelayCommand<in T> : ICommand
    {
        public bool CanExecute(T? parameter);

        public void Execute(T? parameter);
    }
}
