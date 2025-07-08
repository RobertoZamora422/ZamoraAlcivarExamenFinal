using ZamoraAlcivarExamenFinal.ViewModels;

namespace ZamoraAlcivarExamenFinal.Views;

public partial class LogsPage : ContentPage
{
    LogsViewModel ViewModel => BindingContext as LogsViewModel;

    public LogsPage(LogsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (ViewModel.CargarLogsCommand.CanExecute(null))
            ViewModel.CargarLogsCommand.Execute(null);
    }
}