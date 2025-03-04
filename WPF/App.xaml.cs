using WPF.ViewModel;
using WPF.Interface;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WPF.Services;
using WPF_UI.Services;
using WPF.Windows;
using WPF.Service;


namespace WPF
{

    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = Current.Services.GetService<LoginRegisterWindow>();
            mainWindow?.Show();
        }
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            //view principal
            services.AddSingleton<LoginRegisterWindow>();
            services.AddTransient<MainWindow>();
            services.AddTransient<AddWindow>();


            //view viewModels
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<LoginRegisterViewModel>();
            services.AddSingleton<AddViewModel>();
            services.AddSingleton<DashboardViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<RegistroViewModel>();
            services.AddSingleton<ImportViewModel>();
            services.AddSingleton<ObjectOverviewViewModel>();
            services.AddSingleton<ExploreObjectViewModel>();
            services.AddSingleton<ViewModelBase>();
            services.AddSingleton<DataGridViewModel>();
      


            //Services
            services.AddSingleton<Credenciales>();
            services.AddSingleton(typeof(IHttpJsonProvider<>), typeof(HttpJsonService<>));
            services.AddSingleton(typeof(IFileService<>), typeof(FileService<>));
            services.AddSingleton<IStringUtils, StringUtils>();

            return services.BuildServiceProvider();
        }
    }
}


