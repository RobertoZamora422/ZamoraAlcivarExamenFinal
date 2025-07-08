using Microsoft.Extensions.Logging;
using ZamoraAlcivarExamenFinal.Services;
using ZamoraAlcivarExamenFinal.ViewModels;
using ZamoraAlcivarExamenFinal.Views;

namespace ZamoraAlcivarExamenFinal
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Registra servicios
            builder.Services.AddSingleton<DatabaseService>();
            builder.Services.AddSingleton<LogService>();

            // Registra ViewModels
            builder.Services.AddTransient<CrearSuscripcionViewModel>();
            builder.Services.AddTransient<ListaSuscripcionesViewModel>();
            builder.Services.AddTransient<LogsViewModel>();

            // Registra Views
            builder.Services.AddTransient<CrearSuscripcionPage>();
            builder.Services.AddTransient<ListaSuscripcionesPage>();
            builder.Services.AddTransient<LogsPage>();

            return builder.Build();
        }
    }
}