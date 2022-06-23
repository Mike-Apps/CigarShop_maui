namespace CigarShop_maui;
using CigarShop_maui.Services;
using CigarShop_maui.Views;


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

		builder.Services.AddSingleton<CigarServices>();
		builder.Services.AddSingleton<CigarViewModel>();
        builder.Services.AddSingleton<MainPage>();

		builder.Services.AddTransient<CigarDetailsViewModel>();
        builder.Services.AddTransient<DetailsPage>();

		//sensors & Interfaces

		builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
        builder.Services.AddSingleton<IMap>(Map.Default);


        return builder.Build();
	}
}
