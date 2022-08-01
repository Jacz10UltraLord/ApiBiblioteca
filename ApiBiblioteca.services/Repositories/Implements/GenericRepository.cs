using ApiBiblioteca.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;


namespace ApiBiblioteca.services.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly Context context;

        public GenericRepository(Context context)
        {
            this.context = context;
        }


        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

       
    }
}
