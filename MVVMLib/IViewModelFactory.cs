using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLib
{
    public interface IViewModelFactory
    {
        T CreateViewModel<T>() where T : BaseViewModel;
    }
}
