using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ZamoraAlcivarExamenFinal.Models;
using ZamoraAlcivarExamenFinal.Services;

namespace ZamoraAlcivarExamenFinal.ViewModels
{
    public partial class CrearSuscripcionViewModel : ObservableObject
    {
        [ObservableProperty]
        private Suscripcion suscripcion = new Suscripcion();

        private readonly DatabaseService _databaseService;
        private readonly LogService _logService;

        public CrearSuscripcionViewModel(DatabaseService databaseService, LogService logService)
        {
            _databaseService = databaseService;
            _logService = logService;
        }

        [RelayCommand]
        private async Task Guardar()
        {
            int costoEntero = (int)(suscripcion.CostoMensual * 100);

            if (costoEntero % 2 == 0)
            {
                await Shell.Current.DisplayAlert("Error", "El costo mensual debe ser un valor impar.", "OK");
                return;
            }

            await _databaseService.SaveSuscripcionAsync(suscripcion);

            string logEntry = $"Se incluyó el registro {suscripcion.Servicio} el {DateTime.Now:dd/MM/yyyy HH:mm}";
            await _logService.RegistrarLog(logEntry);

            Suscripcion = new Suscripcion();
            await Shell.Current.DisplayAlert("Éxito", "Suscripción guardada correctamente", "OK");
        }
    }
}