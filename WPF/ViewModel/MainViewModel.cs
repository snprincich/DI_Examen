using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using WPF.Windows;
using WPF_UI.Services;


namespace WPF.ViewModel;

public partial class MainViewModel : ViewModelBase  
{
    public MainWindow MainWindow { get; set; }


    private ViewModelBase? _selectedViewModel;
    public DashboardViewModel DashboardViewModel { get; }
    public DataGridViewModel DataGridViewModel { get; }
    public ImportViewModel ImportViewModel { get; }

    public ObjectOverviewViewModel ObjectOverviewViewModel { get; }

    public MainViewModel(DashboardViewModel dashboardViewModel,DataGridViewModel dataGridViewModel, ImportViewModel importViewModel, ObjectOverviewViewModel objectOverviewViewModel)
    {
        DashboardViewModel = dashboardViewModel;
        ImportViewModel = importViewModel;
        ObjectOverviewViewModel = objectOverviewViewModel;
        DataGridViewModel = dataGridViewModel;
        _selectedViewModel = dashboardViewModel;
    }

    public ViewModelBase? SelectedViewModel
    {
        get => _selectedViewModel;
        set => SetProperty(ref _selectedViewModel, value);
    }


    [RelayCommand]
    private async Task SelectViewModelAsync(object? parameter)
    {
        if (parameter is ViewModelBase viewModel)
        {
            SelectedViewModel = viewModel;
            await LoadAsync();
        }
    }

    [RelayCommand]
    private async Task Logout()
    {
        App.Current.Services.GetService<Credenciales>().BorrarCredenciales();
        MainWindow.Close();
    }

    public override async Task LoadAsync()
    {
        if (SelectedViewModel is not null)
        {
            await SelectedViewModel.LoadAsync();
        }
    }





}




