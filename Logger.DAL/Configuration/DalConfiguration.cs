﻿using Logger.DAL.Repositories;
using Logger.DAL.Repositories.LogRepo;
using Microsoft.Extensions.DependencyInjection;

namespace Logger.DAL.Configuration
{
    public static class DalConfiguration
    {
        public static void AddDalServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ILogRepository, LogRepository>();
        }
    }
}
