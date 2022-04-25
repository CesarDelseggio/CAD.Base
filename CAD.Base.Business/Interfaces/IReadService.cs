using CAD.Base.DataAccess.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CAD.Base.Business.Interfaces
{
    public interface IReadService<T> where T : EntityBase
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        Task<int> GetCount();

        Task<bool> Exist(int id);
        Task<bool> Exist(T entity);
    }
}
