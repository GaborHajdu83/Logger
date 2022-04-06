using Logger.DAL.Configuration;
using Logger.ServiceLayer.MappingConfiguration;
using Logger.ServiceLayer.Services.ExcelService;
using Logger.ServiceLayer.Services.LogService;
using Microsoft.Extensions.DependencyInjection;

namespace Logger.ServiceLayer.Configuration
{
    public static class ServiceLayerConfiguration
    {
        public static void AddServiceLayerServices(this IServiceCollection services)
        {
            services.AddDalServices();

            services.AddAutoMapper(typeof(LogProfile));

            services.AddTransient<ILogService, LogService>();
            services.AddTransient<IExcelGenerator, ExcelGenerator>();
        }
    }
}
