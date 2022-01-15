namespace AspNet.BasicDemo.Core.Abstractions;

public interface IContext
{
    IQueryable<T> Set<T>() where T : class;
    void Add(object entity);
    void Remove(object entity);
    void Update(object entity);
    Task<int> SaveChangesAsync();
}