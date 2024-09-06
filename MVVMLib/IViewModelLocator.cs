using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLib
{
    public interface IViewModelLocator
    {
        void Register<TViewModel, TView>(Func<TViewModel> factory) where TViewModel : BaseViewModel where TView : class;

        object Resolve(object view);
    }
}
