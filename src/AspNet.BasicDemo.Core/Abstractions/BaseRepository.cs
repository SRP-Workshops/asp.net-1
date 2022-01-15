namespace AspNet.BasicDemo.Core.Abstractions;

public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly IContext Context;

    protected BaseRepository(IContext context)
    {
        Context = context;
    }

    public Task<TEntity> Get(Guid id) => Context.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id == id);

    public Task<List<TEntity>> GetAll() => Context.Set<TEntity>().ToListAsync();

    public void Add(TEntity entity) => Context.Add(entity);

    public async Task<bool> Remove(Guid id)
    {
        var entity = await Get(id);
        if (entity is not null) Context.Remove(entity);
        return entity is not null;
    }

    public void Update(TEntity entity) => Context.Update(entity);

    public Task SaveChangesAsync() => Context.SaveChangesAsync();
}