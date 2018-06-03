using Business.Core;
using Business.Core.BookingManager;
using Business.Core.Manager;
using Business.Core.TimeManager;
using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiBookingSystem_nutonomy
{
    public static class DependencyMapper
    {
        public static void SetDependencies(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddTransient<IDistance, ManhattenDistance>();
            services.AddTransient<IDistanceManager, DistanceManager>();
            services.AddTransient<IOrigin, Origin>();
            services.AddScoped<IBookingManager, BookingManager>();
            services.AddTransient<ITimeManager, TimeManager>();
        }
    }
}
