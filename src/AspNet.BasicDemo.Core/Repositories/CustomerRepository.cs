namespace AspNet.BasicDemo.Core.Repositories;

public class CustomerRepository : BaseRepository<Entities.Customer>, ICustomerRepository
{
    public CustomerRepository(IContext context) : base(context)
    {
    }
}