using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF.DTOs;
using WPF.Interface;
using WPF.Service;
using WPF.Windows;
using WPF_UI.Constants;
using WPF_UI.Services;

namespace WPF.ViewModel
{
    public partial class DataGridViewModel : ViewModelBase
    {

        [ObservableProperty]
        private ObservableCollection<FerrariDTO> _listaFerrari;

        private readonly IHttpJsonProvider<FerrariDTO> _httpJsonService;
        private IFileService<FerrariDTO> _fileService;

        public DataGridViewModel(IHttpJsonProvider<FerrariDTO> httpJsonService, IFileService<FerrariDTO> fileService)
        {
            _httpJsonService = httpJsonService;
            _fileService = fileService;
        }

        [RelayCommand]
        public void Add(object? parameter)
        {

            var view = App.Current.Services.GetService<AddWindow>();
            var viewmodel = App.Current.Services.GetService<AddViewModel>();

            viewmodel.SelectedView = view;
            view.DataContext = viewmodel;

            view.Show();
            view.Closed += View_Closed;
        }

        private void View_Closed(object sender, EventArgs e)
        {
            LoadAsync();
        }


        private FerrariDTO _ferrariSeleccionado;
        public FerrariDTO FerrariSeleccionado
        {
            get => _ferrariSeleccionado;
            set
            {
                _ferrariSeleccionado = value;
                //OnPropertyChanged(nameof(FerrariSeleccionado));

                /*
                // Aquí puedes realizar acciones cuando cambia la selección
                if (_ferrariSeleccionado != null)
                {
                    Console.WriteLine($"Seleccionado: {_ferrariSeleccionado.Name}");
                }*/
            }
        }

        [RelayCommand]
        public async Task Delete()
        {

            if (_ferrariSeleccionado is FerrariDTO)
            {

                if (await _httpJsonService.Delete($"{ConstantesApi.FERRARI_URL}", _ferrariSeleccionado.Id))
                {
                    LoadAsync();
                }
                else
                {
                    MessageBox.Show("Error", "Error al borrar", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

        }


        [RelayCommand]
        public void SaveToFile()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = ConstantesJson.JSON_FILTER
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                _fileService.Save(saveFileDialog.FileName, ListaFerrari);
            }
        }

        public override async Task LoadAsync()
        {
            if (App.Current.Services.GetService<Credenciales>().GetCredenciales().UserName != null)
            {

                try
                {
                    IEnumerable<FerrariDTO> ferraris = await _httpJsonService.GetAsync(ConstantesApi.FERRARI_URL);
                    ListaFerrari = new ObservableCollection<FerrariDTO>(ferraris.OrderBy(d => d.Id));
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Error al cargar datos: {ex.Message}");
                }

            }

        }

    }
}
