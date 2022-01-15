namespace AspNet.BasicDemo.Core.Repositories;

public class CompanyRepository : BaseRepository<Entities.Company>, ICompanyRepository
{
    public CompanyRepository(IContext context) : base(context)
    {
    }
}