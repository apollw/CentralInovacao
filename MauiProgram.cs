using CentralInovacao.Pages;
using CentralInovacao.Services;
using Microcharts.Maui;

namespace CentralInovacao;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMicrocharts()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<AuthService>();
        builder.Services.AddTransient<ConnectivityService>();
        builder.Services.AddTransient<PageLoading>();
		builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<PageInicio>();		

        return builder.Build();
	}
}
