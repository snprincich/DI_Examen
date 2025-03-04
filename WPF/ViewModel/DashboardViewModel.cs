using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPF.Interface;
using WPF.View;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using WPF_UI.Services;
using WPF_UI.Constants;
using WPF.Windows;
using WPF.DTOs;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using WPF.Service;
using System.Reflection.Metadata;
using System.Windows;

namespace WPF.ViewModel;

public partial class DashboardViewModel : ViewModelBase
{
    [ObservableProperty]
    private int _counter = 0;

    private List<FerrariDTO> _listaFerrari;

    private readonly IHttpJsonProvider<FerrariDTO> _httpJsonService;

    private IFileService<FerrariDTO> _fileService;

    public DashboardViewModel(IHttpJsonProvider<FerrariDTO> httpJsonProvider, IFileService<FerrariDTO> fileService)
    {
        _httpJsonService = httpJsonProvider;
        _fileService = fileService;

        _listaFerrari = new List<FerrariDTO>();
        PagedFerrari = new ObservableCollection<FerrariDTO>();

        ItemsPerPage = 10;
        CurrentPage = 0;
        CurrentPageView = 1;
        TotalPages = 1;
    }

    [ObservableProperty]
    private ObservableCollection<FerrariDTO> pagedFerrari;

    [ObservableProperty]
    private int currentPage;

    [ObservableProperty]
    private int currentPageView;

    [ObservableProperty]
    private int itemsPerPage;

    [ObservableProperty]
    public int totalPages;

    private void SumarPages(int num)
    {
        CurrentPage += num;
        CurrentPageView += num;
    }


    public void MyDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        if (e.Row.Item is FerrariDTO objeto)
        {
            // Aquí llamas al método sobre el objeto editado

            //_httpJsonService.PatchAsync($"{ConstantesApi.COCHE_PATH}{"/"}{objeto.Id}", objeto);
        }
    }

    private void UpdatePaged()
    {

        PagedFerrari.Clear();
        var pagedItems = _listaFerrari.Skip(CurrentPage * ItemsPerPage).Take(ItemsPerPage).ToList();
        foreach (var item in pagedItems)
        {
            PagedFerrari.Add(item);
        }
    }


    [RelayCommand]
    public void PreviousPage()
    {
        if (CurrentPage > 0)
        {
            SumarPages(-1);
            UpdatePaged();
        }
    }

    [RelayCommand]
    public void NextPage()
    {
        if (CurrentPage < TotalPages - 1)
        {
            SumarPages(1);
            UpdatePaged();
        }
    }

    private bool CanGoToPreviousPage() => CurrentPage > 0;

    private bool CanGoToNextPage() => CurrentPage < TotalPages - 1;

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

    [RelayCommand]
    private void OnCounterIncrement()
    {
        Counter++;
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
            _fileService.Save(saveFileDialog.FileName, _listaFerrari);
        }
    }

    public override async Task LoadAsync()
    {
        _listaFerrari.Clear();
        PagedFerrari.Clear();

        if (App.Current.Services.GetService<Credenciales>().GetCredenciales().UserName != null)
        {
            try
            {
                IEnumerable<FerrariDTO> ferraris = await _httpJsonService.GetAsync(ConstantesApi.FERRARI_URL);
                _listaFerrari.AddRange(ferraris.OrderBy(d => d.Id));

                TotalPages = (int)Math.Ceiling((double)_listaFerrari.Count / ItemsPerPage);
                UpdatePaged();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error al cargar datos: {ex.Message}");
            }
        }
    }
}

