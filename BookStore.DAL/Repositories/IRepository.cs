namespace BookStore.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);

        void Delete(TEntity entity);
        
        Task<TEntity?> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        IQueryable<TEntity> GetQueryable();

        Task SaveChangesAsync();
    }
}