
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using WPF.DTOs;
using WPF.Interface;
using WPF.Windows;
using WPF_UI.Constants;



namespace WPF.ViewModel
{
    public partial class AddViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string? marca;
        [ObservableProperty]
        private string? modelo;
        [ObservableProperty]
        private string? precio;



        private readonly IHttpJsonProvider<FerrariDTO> _httpJsonService;
        private AddWindow? _addWindow;
        public AddViewModel(IHttpJsonProvider<FerrariDTO> httpJsonProvider) 
        {
            _httpJsonService = httpJsonProvider;
        }

        [RelayCommand]
        public async Task Post(object? parameter)
        {
            FerrariDTO ferrariDTO = new FerrariDTO
            {
                Name = Marca,
                Cv = Modelo,
                Description = Precio,
                AnoSalida = "1999",
                Image = "a",
                PrecioEstimado = "999",
                PujaInicial = "999"
            };

            
            
            if (await _httpJsonService.PostAsync(ConstantesApi.FERRARI_URL, ferrariDTO) !=null)
            {
                Back();
            }
            else
            {
                MessageBox.Show("Error en el POST. Intente de nuevo.", "Error POST", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        [RelayCommand]
        public void Back()
        {
            //_addWindow.Visibility = Visibility.Hidden;

            _addWindow.Close();
            Marca = null;
            Modelo = null;
            Precio = null;
        }


        public AddWindow? SelectedView
        {
            get => _addWindow;
            set
            {
                SetProperty(ref _addWindow, value);
            }
        }
    }


}
