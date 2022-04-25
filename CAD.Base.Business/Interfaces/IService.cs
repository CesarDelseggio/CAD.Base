using CAD.Base.DataAccess.Data.Models;
using System.Threading.Tasks;

namespace CAD.Base.Business.Interfaces
{
    public interface IService<T> : IReadService<T> where T : EntityBase
    {
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
