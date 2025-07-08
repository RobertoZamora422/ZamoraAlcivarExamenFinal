using ZamoraAlcivarExamenFinal.ViewModels;

namespace ZamoraAlcivarExamenFinal.Views;

public partial class ListaSuscripcionesPage : ContentPage
{
    public ListaSuscripcionesPage(ListaSuscripcionesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}