
global using System;
global using TinyMvvm;
global using Microsoft.Extensions.Logging;
global using NewsApp.Services;
global using NewsApp.ViewModels;
global using NewsApp.Views;
global using System.Collections.ObjectModel;
global using NewsApp.Models;
namespace NewsApp;

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
		builder.Services.AddSingleton<INewsService, NewsService>();

		builder.Services.AddTransient<MainViewModel>();
		builder.Services.AddTransient<MainView>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

