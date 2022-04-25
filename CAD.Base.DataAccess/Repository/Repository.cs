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
    public class Repository<T> : ReadRepository<T>, IRepository<T> where T : EntityBase
    {
        public Repository(ApplicationDbContext context) 
            : base(context)
        {
        }

        public async Task<bool> Create(T entity)
        {
            dbContext.Set<T>().Add(entity);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(T entity)
        {
            dbContext.Update(entity);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(T entity)
        {
            dbContext.Remove(entity);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
