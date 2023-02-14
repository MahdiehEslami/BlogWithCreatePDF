using BlogZamin.EndPoint.BlazorUI.Categories.Services;
using BlogZamin.EndPoint.BlazorUI.Photos.Services;
using Refit;

namespace BlogZamin.EndPoint.BlazorUI.Photos.Configures
{
    public static class ConfigurePhoto
    {
        private const string BaseUrl = "https://localhost:44339/api";

        public static IServiceCollection PhotoServicesConfigure(this IServiceCollection services)
        {
            services.AddScoped<IPhotoServices, PhotoServices>();

            services.AddRefitClient<IPhotoAPI>()
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri(BaseUrl))
                    .SetHandlerLifetime(TimeSpan.FromMinutes(1));

            return services;
        }
    }
}
