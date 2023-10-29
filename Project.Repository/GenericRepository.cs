using Microsoft.EntityFrameworkCore;
using Project.DAL;
using Project.Repository.Common;
using System.ComponentModel.DataAnnotations;

namespace Project.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly VehicleDbContext _db;

        public GenericRepository(VehicleDbContext db)
        {
            _db = db;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _db.Set<TEntity>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
           var entity = await GetByIdAsync(id);
           _db.Set<TEntity>().Remove(entity);

            await _db.SaveChangesAsync();


        }

        public async Task<bool> Exists(int id)
        {
            var entity = await _db.Set<TEntity>().FindAsync(id);

            if (entity == null)
            {
                return false;
            }

            return true;
        }

        public  async Task<List<TEntity>> GetAllAsync()
        {
            var entity = await _db.Set<TEntity>().ToListAsync();
            return entity;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _db.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            return entity;

        }
        

        async Task IGenericRepository<TEntity>.UpdateAsync(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}