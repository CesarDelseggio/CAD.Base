using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using CAD.Base.Business.Interfaces;
using CAD.Base.Business.Services;
using CAD.Base.DataAccess.Data.Models;
using CAD.Base.DataAccess;
using Microsoft.Extensions.Configuration;

namespace CAD.Base.Business
{
    public static class Startup
    {
        public static void CongfigureBusiness(this IServiceCollection services, IConfiguration Configuration) 
        {
            services.ConfigureDataAccess(Configuration);

            services.AddTransient<IReadService<Log>, ReadService<Log>>();
            services.AddTransient<IService<Log>, Service<Log>>();
        }
    }
}
