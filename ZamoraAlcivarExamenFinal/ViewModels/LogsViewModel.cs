using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ZamoraAlcivarExamenFinal.Services;

namespace ZamoraAlcivarExamenFinal.ViewModels
{
    public partial class LogsViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<string> logs;

        private readonly LogService _logService;

        public LogsViewModel(LogService logService)
        {
            _logService = logService;
            logs = new List<string>();
        }

        [RelayCommand]
        private async Task CargarLogs()
        {
            Logs = await _logService.ObtenerLogs();
        }
    }
}