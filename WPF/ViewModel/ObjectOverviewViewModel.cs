using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.DTOs;
using WPF.Interface;
using WPF.Models;
using WPF.Windows;
using WPF_UI.Constants;

namespace WPF.ViewModel
{
    public partial class ObjectOverviewViewModel : ViewModelBase
    {

        [ObservableProperty]
        private ObservableCollection<FerrariModel> _items;

        private readonly IHttpJsonProvider<FerrariDTO> _httpJsonProvider;
        private readonly ExploreObjectViewModel _exploreObjectViewModel;
        private readonly IStringUtils _stringUtils;

        [ObservableProperty]
        private ViewModelBase? _selectedViewModel;

        public ObjectOverviewViewModel(IHttpJsonProvider<FerrariDTO> httpJsonProvider,
            ExploreObjectViewModel exploreObjectViewModel, IStringUtils stringUtils)
        {
            _httpJsonProvider = httpJsonProvider;
            _exploreObjectViewModel = exploreObjectViewModel;
            _stringUtils = stringUtils;
            _items = new ObservableCollection<FerrariModel>();
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

        public override async Task LoadAsync()
        {
            IEnumerable<FerrariDTO> objetos = await _httpJsonProvider.GetAsync(ConstantesApi.FERRARI_URL);
            Items = new ObservableCollection<FerrariModel>();
            foreach (var objeto in objetos)
            {
                Items.Add(FerrariModel.CreateModelFromDTO(objeto));
            }
        }

        [RelayCommand]
        public async Task SelectViewModel(object? parameter)
        {

                _exploreObjectViewModel.SetIdPlanet(_stringUtils.ConvertToInteger(parameter?.ToString() ?? string.Empty) ?? int.MinValue);
                _exploreObjectViewModel.SetParentViewModel(this);
                SelectedViewModel = _exploreObjectViewModel;
                await _exploreObjectViewModel.LoadAsync();
            

        }
    }
}
