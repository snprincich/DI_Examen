using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.DTOs;
using WPF.Interface;
using WPF_UI.Constants;

namespace WPF.ViewModel
{
    public partial class ImportViewModel : ViewModelBase
    {
        private readonly IFileService<FerrariDTO> _fileService;

        private readonly IHttpJsonProvider<FerrariDTO> _httpJsonService;

        [ObservableProperty]
        private ObservableCollection<FerrariDTO> dicatadores;

        public ImportViewModel(IFileService<FerrariDTO> fileService, IHttpJsonProvider<FerrariDTO> httpJsonProvider)
        {
            _fileService = fileService;
            _httpJsonService = httpJsonProvider;
        }


        [RelayCommand]
        public async Task LoadFromFile()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = ConstantesJson.JSON_FILTER
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var datos = _fileService.Load(openFileDialog.FileName);
                //await _httpJsonService.DeleteAll(ConstantesApi.FERRARI_URL + "deleteAll");
                foreach (var dato in datos)
                {
                    _httpJsonService.PostAsync(ConstantesApi.FERRARI_URL, dato);
                }
            }
        }
    }
}
