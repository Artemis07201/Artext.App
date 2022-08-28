namespace Artext
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            MauiAppBuilder Builder = MauiApp.CreateBuilder();
            Builder
                .UseMauiApp<App>()
                .ConfigureFonts(Fonts =>
                {
                    Fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    Fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            return Builder.Build();
        }
    }
}