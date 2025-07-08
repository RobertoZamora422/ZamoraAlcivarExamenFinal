using ZamoraAlcivarExamenFinal.ViewModels;

namespace ZamoraAlcivarExamenFinal.Views;

public partial class CrearSuscripcionPage : ContentPage
{
    public CrearSuscripcionPage(CrearSuscripcionViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}