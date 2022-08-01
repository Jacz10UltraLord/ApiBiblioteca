using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBiblioteca.services.Services
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> Insert(TEntity entity);
        
    }
}
