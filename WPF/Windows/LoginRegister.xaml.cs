using System.Windows;
using WPF.ViewModel;

namespace WPF.Windows
{
    public partial class LoginRegisterWindow : Window
    {
        private readonly LoginRegisterViewModel _viewModel;

        public LoginRegisterWindow(LoginRegisterViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            Loaded += LoginRegisterWindow_Loaded;
        }

        //De Normal no ponemos NUNCA async void, es siempre Task,
        //es necesario en este caso por respetar la signatura de Loaded
        private async void LoginRegisterWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }
    }
}
