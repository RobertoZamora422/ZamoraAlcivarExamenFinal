using ZamoraAlcivarExamenFinal.ViewModels;

namespace ZamoraAlcivarExamenFinal.Views;

public partial class ListaSuscripcionesPage : ContentPage
{
    ListaSuscripcionesViewModel ViewModel => BindingContext as ListaSuscripcionesViewModel;

    public ListaSuscripcionesPage(ListaSuscripcionesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (ViewModel.CargarSuscripcionesCommand.CanExecute(null))
            ViewModel.CargarSuscripcionesCommand.Execute(null);
    }
}