using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MVVMLib.Data;
using MVVMLib.Navigation;
using MVVMLib.UI.ViewModels;

namespace MVVMLib.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;

        public App()
        {

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            NavigationService.RegisterViewModelFactory<SomeViewModel>(navigationService => new SomeViewModel(navigationService));
            NavigationService.RegisterViewModelFactory<SomeDumbViewModel>(navigationService => new SomeDumbViewModel(navigationService));

            NavigationService ns = new();
            ns.NavigateTo<SomeViewModel>();

            var mw = new MainWindow();
            mw.DataContext = new MainWindowViewModel(ns);
            mw.Show();

            NavigationService ns2 = new();
            ns2.NavigateTo<SomeDumbViewModel>();

            var mw2 = new MainWindow();
            mw2.DataContext = new MainWindowViewModel(ns2);
            mw2.Show();
        }
    }

}
