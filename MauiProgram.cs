using Microsoft.Extensions.Logging;

namespace SearchBarCancelButtonHandler;

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

        Microsoft.Maui.Handlers.SearchBarHandler.Mapper.AppendToMapping("MySearchBarCustomization", (handler, view) =>
        {
#if IOS
            handler.PlatformView.SetShowsCancelButton(false,false);
#endif
        });

        return builder.Build();
	}
}
