using CommunityToolkit.Mvvm.Input;
using WPF.Interface;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Metadata;
using WPF.Services;
using WPF.Windows;
using WPF.DTOs;

namespace WPF.ViewModel
{
    public partial class LoginViewModel : ViewModelBase
    {
        private readonly IHttpJsonProvider<UserDTO> _httpJsonService;


        [ObservableProperty]
        private string _name = "sufrido";

        [ObservableProperty]
        private string _password = "wnD/LbJq?9t,}-628%)";

        public LoginViewModel(IHttpJsonProvider<UserDTO> httpJsonProvider)
        {
            _httpJsonService = httpJsonProvider;

        }

        [RelayCommand]
        public async Task Login()
        {

            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Por favor, rellene ambos campos.", "Error de Inicio de Sesión", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            LoginDTO loginDTO = new LoginDTO
            {
                UserName = this.Name,
                Password = this.Password
            };

            try
            {

                UserDTO userDTO = await _httpJsonService.LoginAsync(loginDTO);

                if (userDTO != null && userDTO.IsSuccess)
                {
                    AbrirWindow();

                    Name = string.Empty;
                    Password = String.Empty;

                }
                else
                {

                    MessageBox.Show("Credenciales incorrectas. Intente de nuevo.", "Error de Inicio de Sesión", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Ocurrió un error durante el inicio de sesión: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void AbrirWindow()
        {
            var mainWindow = App.Current.Services.GetService<MainWindow>();
            mainWindow.Closed += View_Closed;

            var mainViewModel = App.Current.Services.GetService<MainViewModel>();
            mainViewModel.MainWindow = mainWindow;

            mainWindow?.Show();
            App.Current.MainWindow.Hide();
        }

        private void View_Closed(object sender, EventArgs e)
        {
            LoadAsync();
            App.Current.MainWindow.Show();
        }

        [RelayCommand]
        private async void Register()
        {
            var viewModel = App.Current.Services.GetService<LoginRegisterViewModel>();
            viewModel.SelectViewModelAsync(viewModel.RegistroViewModel);
        }
    }
}

