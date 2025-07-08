using ZamoraAlcivarExamenFinal.ViewModels;

namespace ZamoraAlcivarExamenFinal.Views;

public partial class LogsPage : ContentPage
{
    public LogsPage(LogsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}