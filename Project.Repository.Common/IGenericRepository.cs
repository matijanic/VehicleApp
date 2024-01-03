namespace Project.Repository.Common
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
       

        Task AddAsync(TEntity entity);

        Task DeleteAsync (int id);

        Task UpdateAsync(TEntity entity);

        



    }
}