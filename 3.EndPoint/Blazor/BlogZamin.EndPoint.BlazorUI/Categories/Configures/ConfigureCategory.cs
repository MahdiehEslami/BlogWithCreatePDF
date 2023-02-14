using BlogZamin.EndPoint.BlazorUI.Categories.Services;
using Refit;

namespace BlogZamin.EndPoint.BlazorUI.Categories.Configures
{
    public static class ConfigureCategory
    {
        private const string BaseUrl = "https://localhost:44339/api";

        public static IServiceCollection CategoryServicesConfigure(this IServiceCollection services)
        {
            services.AddScoped<ICategoryServices, CategoryServices>();

            services.AddRefitClient<ICategoryAPI>()
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri(BaseUrl))
                    .SetHandlerLifetime(TimeSpan.FromMinutes(1));

            return services;
        }
    }
}
