using AdminUI.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;

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
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5000") });
            builder.Services.AddMudServices(config =>
             {
                 config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

                 config.SnackbarConfiguration.PreventDuplicates = false;
                 config.SnackbarConfiguration.NewestOnTop = false;
                 config.SnackbarConfiguration.ShowCloseIcon = true;
                 config.SnackbarConfiguration.VisibleStateDuration = 10000;
                 config.SnackbarConfiguration.HideTransitionDuration = 500;
                 config.SnackbarConfiguration.ShowTransitionDuration = 500;
                 config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
             });
            await builder.Build().RunAsync();
        }
    }
}
