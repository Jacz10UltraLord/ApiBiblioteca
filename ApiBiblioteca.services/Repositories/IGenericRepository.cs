using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBiblioteca.services.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> Insert(TEntity entity);
        
    }
}
