using CommunityToolkit.Maui;
namespace weather;

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
			});

		builder.UseMauiApp<App>().UseMauiCommunityToolkit();

		return builder.Build();
	}
}
