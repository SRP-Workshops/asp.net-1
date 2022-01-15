namespace AspNet.BasicsDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public Task<IEnumerable<CompanyViewModel>> Get() => _companyService.GetAllCompanies();

    [HttpGet("{id:guid}")]
    public Task<CompanyViewModel> GetById(Guid id) => _companyService.GetCompanyById(id);

    [HttpPost]
    public Task<CompanyViewModel> Post(CreateCompanyCommand command) => _companyService.CreateCompany(command);

    [HttpPatch]
    public Task Patch(UpdateCompanyInfoCommand command) => _companyService.UpdateCompanyInfo(command);

    [HttpDelete("{id:guid}")]
    public Task Delete(Guid id) => _companyService.DeleteCompany(id);
}