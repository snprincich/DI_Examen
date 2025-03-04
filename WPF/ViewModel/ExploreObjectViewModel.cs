using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.DTOs;
using WPF.Interface;
using WPF.Models;
using WPF_UI.Constants;

namespace WPF.ViewModel
{
    public partial class ExploreObjectViewModel : ViewModelBase
    {
        public ObjectOverviewViewModel ObjectOverviewViewModel { get; set; }
        private int _ferrariId;


        [ObservableProperty]
        private ObservableCollection<FerrariModel> _items;

        private IEnumerable<FerrariDTO> _ferraris;

        [ObservableProperty]
        private FerrariModel _ferrari;


        private readonly IHttpJsonProvider<FerrariDTO> _httpJsonProvider;
        private IFileService<FerrariDTO> _fileService;

        public ExploreObjectViewModel(IHttpJsonProvider<FerrariDTO> httpJsonProvider, IFileService<FerrariDTO> fileService)
        {
            _httpJsonProvider = httpJsonProvider;
            _fileService = fileService;

            _items = new ObservableCollection<FerrariModel>();
        }

        public void SetIdPlanet(int id)
        {
            _ferrariId = id;
        }

        public override async Task LoadAsync()
        {

            _ferraris = await _httpJsonProvider.GetAsync(ConstantesApi.FERRARI_URL);
            Items = new ObservableCollection<FerrariModel>();
            foreach (var ferrari in _ferraris)
            {
                Items.Add(FerrariModel.CreateModelFromDTO(ferrari));
            }
            Ferrari = FerrariModel.CreateModelFromDTO(_ferraris.FirstOrDefault(x => x.Id == _ferrariId) ?? new FerrariDTO());
        }



        internal void SetParentViewModel(ViewModelBase objectOverview)
        {
            if (objectOverview is ObjectOverviewViewModel)
            {
                ObjectOverviewViewModel = (ObjectOverviewViewModel)objectOverview;
            }
        }

        [RelayCommand]
        private async Task Close()
        {
            
            if (ObjectOverviewViewModel != null)
            {
                ObjectOverviewViewModel.SelectedViewModel = null;
                ObjectOverviewViewModel.LoadAsync();
            }
         
        }

        [RelayCommand]
        private async Task Save(object? parameter)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = ConstantesJson.JSON_FILTER
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                _fileService.Save(saveFileDialog.FileName, _ferraris.FirstOrDefault(x => x.Id == _ferrariId) ?? new FerrariDTO());
            }
        }

        [RelayCommand]
        private async Task Delete()
        {
            await _httpJsonProvider.Delete(ConstantesApi.FERRARI_URL, _ferrariId);
            Close();
        }

    }
}
