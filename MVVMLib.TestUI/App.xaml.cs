using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Extensions.DependencyInjection;
using MVVMLib.TestUI.ViewModels;

namespace MVVMLib.TestUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IServiceCollection serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);
            
            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mw = new MainWindow();
            var vm = ServiceProvider.GetRequiredService<MainViewModel>();
            vm.NavigateTo<TestViewModel>();
            mw.DataContext = vm;

            //var navService = ServiceProvider.GetRequiredService<NavigationService>();
            //navService.NavigateTo<TestViewModel>();


            var mw2 = new MainWindow();
            var vm2 = ServiceProvider.GetRequiredService<MainViewModel>();
            vm2.NavigateTo<SomeOtherTestViewModel>();
            mw2.DataContext = vm2;

            mw2.Show();
            mw.Show();
        }

        private void ConfigureServices(IServiceCollection serviceCollection)
        {
            //serviceCollection.AddSingleton<NavigationService>();
            //serviceCollection.AddTransient<TestViewModel>();
            //serviceCollection.AddTransient<MainWindow>();

            serviceCollection.AddTransient<MainViewModel>();
            serviceCollection.AddTransient<SomeOtherTestViewModel>();
            serviceCollection.AddTransient<TestViewModel>();

            serviceCollection.AddScoped<NavigationService>();

            serviceCollection.AddSingleton<IViewModelFactory, ViewModelFactory>();
        }
    }

}
