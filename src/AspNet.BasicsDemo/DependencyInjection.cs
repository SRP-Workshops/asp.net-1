namespace AspNet.BasicsDemo;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var useMemory = configuration.GetValue<bool>("UseInMemoryDatabase");
        if (useMemory)
        {
            serviceCollection.AddDbContext<IContext, AppDbContext>(builder => builder.UseInMemoryDatabase("AspNetBasicDemo"));
        }
        else
        {
            var connectionString = configuration.GetConnectionString("localConnectionString");
            serviceCollection.AddDbContext<IContext, AppDbContext>(builder => builder.UseNpgsql(connectionString));
        }
    }
}