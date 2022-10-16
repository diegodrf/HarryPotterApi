using Microsoft.OpenApi.Models;

namespace HarryPotterApi.DependencyIntjections
{
    public static class SwaggerDepentendyInjectionExtensions
    {
        public static void AddSwaggerConfigurations(this IServiceCollection services)
        {
            services.AddSwaggerGen(configurations =>
            {
                configurations.EnableAnnotations();
                configurations.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Harry Potter API",
                        Version = "v1",
                        License = new OpenApiLicense { Name = "MIT License", Url = new Uri("https://github.com/diegodrf/HarryPotterApi/blob/main/LICENSE.md") },
                        Contact = new OpenApiContact
                        {
                            Name = "Diego Faria",
                            Url = new Uri("https://github.com/diegodrf")
                        }
                    });
            });
        }
    }
}
