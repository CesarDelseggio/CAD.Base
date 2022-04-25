using CAD.Base.DataAccess.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CAD.Base.DataAccess.Interfaces
{
    public interface IRepository<T> : IReadRepository<T> where T : EntityBase
    {
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);

    }
}
