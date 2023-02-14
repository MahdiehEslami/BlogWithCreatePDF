using BlogZamin.EndPoint.BlazorUI;
using BlogZamin.EndPoint.BlazorUI.Blogs.Configures;
using BlogZamin.EndPoint.BlazorUI.Categories.Configures;
using BlogZamin.EndPoint.BlazorUI.Photos.Configures;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.CategoryServicesConfigure();
builder.Services.PhotoServicesConfigure();
builder.Services.BlogServicesConfigure();
await builder.Build().RunAsync();
