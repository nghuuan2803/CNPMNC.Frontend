using AdminUI.ApiServices;
using AdminUI.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using Tewr.Blazor.FileReader;

namespace AdminUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddMudServices();
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<WarehouseServices>();
            builder.Services.AddScoped<EmployeeServices>();
            builder.Services.AddScoped<AgencyServices>();
            builder.Services.AddScoped<ImportServices>();
            builder.Services.AddScoped<ExportServices>();


            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5000") });
            builder.Services.AddMudServices(config =>
             {
                 config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;

                 config.SnackbarConfiguration.PreventDuplicates = false;
                 config.SnackbarConfiguration.NewestOnTop = false;
                 config.SnackbarConfiguration.ShowCloseIcon = true;
                 config.SnackbarConfiguration.VisibleStateDuration = 10000;
                 config.SnackbarConfiguration.HideTransitionDuration = 500;
                 config.SnackbarConfiguration.ShowTransitionDuration = 500;
                 config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
             });
            builder.Services.AddAuthorizationCore();
            //builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();
            builder.Services.AddScoped<JwtAuthenticationStateProvider>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<AuthenticationService>();
            builder.Services.AddOptions();
            builder.Services.AddFileReaderService(options => options.UseWasmSharedBuffer = true);

            await builder.Build().RunAsync();
        }
    }
}
