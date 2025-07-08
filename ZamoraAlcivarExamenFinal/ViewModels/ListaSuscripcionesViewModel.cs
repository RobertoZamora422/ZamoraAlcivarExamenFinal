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
    public partial class ListaSuscripcionesViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<Suscripcion> suscripciones;

        private readonly DatabaseService _databaseService;

        public ListaSuscripcionesViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
            suscripciones = new List<Suscripcion>();
        }

        [RelayCommand]
        private async Task CargarSuscripciones()
        {
            Suscripciones = await _databaseService.GetSuscripcionesAsync();
        }
    }
}