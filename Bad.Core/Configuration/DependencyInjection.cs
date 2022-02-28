using Bad.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bad.Core.Configuration
{
    public static class DependencyInjection
    {
        public static void AddBadCoreComponents(this IServiceCollection services)
        {
            services.AddScoped<IFilesService, FilesService>();
        }
    }
}
