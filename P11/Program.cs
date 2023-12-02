using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using P06.Shared.Services.ProductService;
using P06.Shared.Services.BookService;
using P04WeatherForecastAPI.Client.Configuration;

using P04WeatherForecastAPI.Client.Services.BookServices;
using P05Shop.API.Services.ProductService;
using P05Shop.API.Services.BookService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<ShopContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
//builder.Configuration.AddJsonFile("appsettings.json");



var appSettings = builder.Configuration.GetSection(nameof(AppSettings));
var appSettingsSection = appSettings.Get<AppSettings>();
builder.Services.Configure<AppSettings>(appSettings);

var uriBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl)
{
    Path = appSettingsSection.BaseBookEndpoint.Base_url,
};
//Microsoft.Extensions.Http
builder.Services.AddHttpClient<IBookService, P04WeatherForecastAPI.Client.Services.BookServices.BookService>(client => client.BaseAddress = uriBuilder.Uri);


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();

