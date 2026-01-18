using Microsoft.Extensions.DependencyInjection;
using processum.Services;
using processum.Services.interfaces;

namespace processum.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEntityService, EntityService>();
            services.AddScoped<IJudicialProcessService, JudicialProcessService>();  

            return services;
        }
    }
}
