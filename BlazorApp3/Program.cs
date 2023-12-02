using BlazorApp3;
using Configuration;
using Services.BookServices;
using Microsoft.Extensions.DependencyInjection;
using P06.Shared.Services.BookService;
using P06.Shared.Services.ProductService;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using P11BlazorWebAssembly.Client.Services.CustomAuthStateProvider;
using P06Shop.Shared.Services.AuthService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


var appSettings = builder.Configuration.GetSection(nameof(AppSettings));
var appSettingsSection = appSettings.Get<AppSettings>();

var uriBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl)
{
    Path = appSettingsSection.BaseBookEndpoint.Base_url,
};
//Microsoft.Extensions.Http
builder.Services.AddHttpClient<IBookService, BookService>(client => client.BaseAddress = uriBuilder.Uri);

builder.Services.AddSingleton<IOptions<AppSettings>>(new OptionsWrapper<AppSettings>(appSettingsSection));

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
var uriBuilder2 = new UriBuilder(appSettingsSection.BaseAPIUrl)
{
    //Path = appSettingsSection.BaseBookEndpoint.Base_url,
};
builder.Services.AddHttpClient<IAuthService, AuthService>(client => client.BaseAddress = uriBuilder2.Uri);



await builder.Build().RunAsync();
