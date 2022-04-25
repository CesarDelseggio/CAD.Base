using CAD.Base.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAD.Base.Business
{
    public class ServiceDbContext : DataAccess.Data.ApplicationDbContext
    {
        public ServiceDbContext(DbContextOptions options) 
            : base(options)
        {
        }
    }
}
