using CAD.Base.DataAccess.Data;
using CAD.Base.DataAccess.Data.Models;
using CAD.Base.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CAD.Base.DataAccess.Repository
{
    public class ReadRepository<T> : IReadRepository<T> where T : EntityBase
    {
        protected ApplicationDbContext dbContext;

        public ReadRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public async Task<bool> Exist(int id)
        {
            return await dbContext.Set<T>().FindAsync(id) != null;
        }

        public async Task<T> Get(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<int> GetCount()
        {
            return await dbContext.Set<T>().CountAsync();
        }
    }
}
