using BlogZamin.EndPoint.BlazorUI.Blogs.Services;
using Refit;

namespace BlogZamin.EndPoint.BlazorUI.Blogs.Configures
{
    public static class ConfigureBlog
    {
        private const string BaseUrl = "https://localhost:44339/api";

        public static IServiceCollection BlogServicesConfigure(this IServiceCollection services)
        {
            services.AddScoped<IBlogServices, BlogServices>();

            services.AddRefitClient<IBlogAPI>()
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri(BaseUrl))
                    .SetHandlerLifetime(TimeSpan.FromMinutes(1));

            return services;
        }
    }
}
