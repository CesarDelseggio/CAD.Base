using CAD.Base.DataAccess.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CAD.Base.DataAccess.Interfaces
{
    public interface IReadRepository<T> where T : EntityBase
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        Task<int> GetCount();

        Task<bool> Exist(int id);
    }
}
