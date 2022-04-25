using CAD.Base.Business.Interfaces;
using CAD.Base.DataAccess.Data.Models;
using CAD.Base.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CAD.Base.Business.Services
{
    public class Service<T> : ReadService<T>, IService<T> where T : EntityBase
    {
        public Service(IRepository<T> repository) 
            : base(repository)
        {

        }

        public Task<bool> Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
