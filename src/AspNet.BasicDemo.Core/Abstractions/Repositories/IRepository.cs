namespace AspNet.BasicDemo.Core.Abstractions.Repositories;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> Get(Guid id);
    Task<List<TEntity>> GetAll();
    void Add(TEntity entity);
    Task<bool> Remove(Guid id);
    void Update(TEntity entity);
    Task SaveChangesAsync();
}