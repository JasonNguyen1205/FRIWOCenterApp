using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using FRIWOCenter.Shared.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

#region ConfigureServices

// setting client host environment 
builder.Services.AddSingleton<IHostingEnvironment>(
    new HostingEnvironment() { EnvironmentName = builder.HostEnvironment.Environment });

// adding client app settings 
var applicationSettingsSection = builder.Configuration.GetSection("ApplicationSettings");
builder.Services.Configure<ApplicationSettings>(options =>
{
    applicationSettingsSection.Bind(options);
});

// adding application services
builder.Services.AddBlazorWASM(applicationSettingsSection.Get<ApplicationSettings>());

#endregion

await builder.Build().RunAsync();
