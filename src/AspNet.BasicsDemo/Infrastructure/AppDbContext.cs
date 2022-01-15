namespace AspNet.BasicsDemo.Infrastructure;

public sealed class AppDbContext : DbContext, IContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public new IQueryable<T> Set<T>() where T : class => base.Set<T>();

    public new void Add(object entity) => base.Add(entity);

    public new void Remove(object entity) => base.Remove(entity);

    public new void Update(object entity) => base.Update(entity);

    public Task<int> SaveChangesAsync() => base.SaveChangesAsync();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}