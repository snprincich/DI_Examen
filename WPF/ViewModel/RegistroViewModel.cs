using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPF.Interface;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WPF.Services;
using WPF.DTOs;

namespace WPF.ViewModel
{
    public partial class RegistroViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _userName;

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;


        private readonly IHttpJsonProvider<UserDTO> _httpJsonService;

        public RegistroViewModel(IHttpJsonProvider<UserDTO> httpJsonProvider)
        {
            _httpJsonService = httpJsonProvider;
        }

        [RelayCommand]
        public void ToLoginPage()
        {
            var viewModel = App.Current.Services.GetService<LoginRegisterViewModel>();
            viewModel.SelectViewModelAsync(viewModel.LoginViewModel);
        }

        [RelayCommand]
        public async Task Registro()
        {

            if (string.IsNullOrEmpty(Name) ||
                string.IsNullOrEmpty(UserName) ||
                string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Por favor, rellene todos los campos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            RegistroDTO registroDTO = new RegistroDTO
            {
                Name = this.Name,
                UserName = this.UserName,
                Email = this.Email,
                Password = this.Password,
                Role = "admin"
            };

            try
            {
                UserDTO userDTO = await _httpJsonService.RegistroAsync(registroDTO);
                if (userDTO != null && userDTO.IsSuccess)
                {
                    ToLoginPage();
                }
                else
                {
                    MessageBox.Show($"Error en el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error durante el registro: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}


