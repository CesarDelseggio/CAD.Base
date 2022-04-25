using CAD.Base.DataAccess.Data;
using CAD.Base.DataAccess.Data.Models;
using CAD.Base.DataAccess.Interfaces;
using CAD.Base.DataAccess.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAD.Base.DataAccess
{
    public static class Startup
    {
        public static void ConfigureDataAccess(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IReadRepository<Log>, ReadRepository<Log>>();
            services.AddTransient<IRepository<Log>, Repository<Log>>();
        }
    }
}
