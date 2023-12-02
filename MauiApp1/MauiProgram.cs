using Microsoft.Extensions.Logging;
using Configuration;
using P06.Shared.Services.BookService;
using Services.BookServices;
using P12MAUI.Client.ViewModels;
using P04WeatherForecastAPI.Client.ViewModels;
using P12MAUI.Client;
using P06Shop.Shared.MessageBox;
using P12MAUI.Client.MessageBox;
using Microsoft.Extensions.Options;

namespace MauiApp1
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


            ConfigureServices(builder.Services);
            return builder.Build();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = ConfigureAppSettings(services);
            ConfigureAppServices(services, appSettingsSection);
            ConfigureViewModels(services);
            ConfigureViews(services);
            ConfigureHttpClients(services, appSettingsSection);
        }

        private static AppSettings ConfigureAppSettings(IServiceCollection services)
        {
            var appSettingsSection = new AppSettings()
            {
                BaseAPIUrl = "http://localhost:5093",
                BaseBookEndpoint = new BaseBookEndpoint()
                {
                    Base_url= "api/Book/",
                    AddBookAsync= "createBook",
                    DeleteBookAsync= "DeleteBook",
                    GetBooksAsync= "ReadBooks",
                    UpdateBookAsync= "UpdateBook",
                },
            };
            services.AddSingleton<IOptions<AppSettings>>(new OptionsWrapper<AppSettings>(appSettingsSection));

            return appSettingsSection;
        }

        private static void ConfigureAppServices(IServiceCollection services, AppSettings appSettings)
        {
            services.AddSingleton<IConnectivity>(Connectivity.Current);
            services.AddSingleton<IGeolocation>(Geolocation.Default);
            services.AddSingleton<IMap>(Map.Default);

            services.AddSingleton<IBookService, BookService>();
            services.AddSingleton<IMessageDialogService, MauiMessageDialogService>();
        }

        private static void ConfigureViewModels(IServiceCollection services)
        {

            // konfiguracja viewModeli 


            services.AddSingleton<BookViewModel>();
            services.AddTransient<BookDetailsViewModel>();

            // services.AddSingleton<BaseViewModel,MainViewModelV3>();
        }

        private static void ConfigureViews(IServiceCollection services)
        {
            // konfiguracja okienek 
            services.AddSingleton<MainPage>();
            services.AddTransient<BookDetailsView>();
        }

        private static void ConfigureHttpClients(IServiceCollection services, AppSettings appSettingsSection)
        {
            var uriBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl)
            {
                Path = appSettingsSection.BaseBookEndpoint.Base_url,
            };
            //Microsoft.Extensions.Http
            services.AddHttpClient<IBookService, BookService>(client => client.BaseAddress = uriBuilder.Uri);
        }
    }
}