namespace AspNet.BasicDemo.Core;

public static class DependencyInjection
{
    public static void AddBasicDemoCore(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICompanyRepository, CompanyRepository>();
        serviceCollection.AddScoped<ICustomerRepository, CustomerRepository>();

        serviceCollection.AddScoped<ICompanyService, CompanyService>();
        serviceCollection.AddScoped<ICustomerService, CustomerService>();
        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}