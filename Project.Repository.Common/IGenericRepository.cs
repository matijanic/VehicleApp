namespace Project.Repository.Common
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> AddAsync(TEntity entity);

        Task DeleteAsync (int id);

        Task UpdateAsync(TEntity entity);

        Task<bool>Exists(int id);



    }
}