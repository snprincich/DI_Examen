using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF.Windows;

namespace WPF.ViewModel
{
    public partial class LoginRegisterViewModel : ViewModelBase
    {
        private Window _window = App.Current.MainWindow;


        private ViewModelBase? _selectedViewModel;

        public LoginRegisterViewModel( LoginViewModel loginViewModel, RegistroViewModel registroViewModel)
        {
            LoginViewModel = loginViewModel;
            RegistroViewModel = registroViewModel;
            _selectedViewModel = loginViewModel;
        }

        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set => SetProperty(ref _selectedViewModel, value);
        }

        public LoginViewModel LoginViewModel { get; }
        public RegistroViewModel RegistroViewModel { get; }


        public override async Task LoadAsync()
        {
            if (SelectedViewModel is not null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }

        [RelayCommand]
        public async Task SelectViewModelAsync(object? parameter)
        {
            if (parameter is ViewModelBase viewModel)
            {
                SelectedViewModel = viewModel;
                await LoadAsync();
            }
        }
    }
}
