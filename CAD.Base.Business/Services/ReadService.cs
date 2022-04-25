using CAD.Base.Business.Interfaces;
using CAD.Base.DataAccess.Data.Models;
using CAD.Base.DataAccess.Interfaces;
using CAD.Base.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CAD.Base.Business.Services
{
    public class ReadService<T> : IReadService<T> where T : EntityBase
    {
        protected DataAccess.Interfaces.IReadRepository<T> repository;
        public ReadService(DataAccess.Interfaces.IReadRepository<T> repository)
        {
            this.repository = repository;
        }

        public Task<T> Get(int id)
        {
            return repository.Get(id);
        }

        public Task<List<T>> GetAll()
        {
            return repository.GetAll();
        }

        public Task<int> GetCount()
        {
            return repository.GetCount();
        }

        public Task<bool> Exist(int id)
        {
            return repository.Exist(id);
        }

        public Task<bool> Exist(T entity)
        {
            return repository.Exist(entity.Id);
        }
    }
}
