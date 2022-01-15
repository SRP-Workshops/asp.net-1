using AspNet.BasicDemo.Core.Exceptions;

namespace AspNet.BasicDemo.Core.Company;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public CompanyService(ICompanyRepository companyRepository, ILogger<CompanyService> logger, IMapper mapper)
    {
        _companyRepository = companyRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CompanyViewModel>> GetAllCompanies()
    {
        _logger.LogInformation("Getting companies");
        var companies = await _companyRepository.GetAll();
        var companyViewModels = _mapper.Map<List<CompanyViewModel>>(companies);
        _logger.LogInformation($"{companies.Count} companies found");
        return companyViewModels;
    }

    public async Task<CompanyViewModel> GetCompanyById(Guid id)
    {
        _logger.LogInformation($"Getting company with id: {id}");
        var company = await _companyRepository.Get(id);
        var companyViewModel = _mapper.Map<CompanyViewModel>(company);
        return companyViewModel;
    }

    public async Task<CompanyViewModel> CreateCompany(CreateCompanyCommand createCompanyCommand)
    {
        _logger.LogInformation($"Creating a company {createCompanyCommand.Name}");
        var company = _mapper.Map<Entities.Company>(createCompanyCommand);
        _companyRepository.Add(company);
        await _companyRepository.SaveChangesAsync();
        var companyViewModel = _mapper.Map<CompanyViewModel>(company);
        return companyViewModel;
    }

    public async Task UpdateCompanyInfo(UpdateCompanyInfoCommand updateCompanyInfoCommand)
    {
        _logger.LogInformation($"Updating company {updateCompanyInfoCommand.CompanyId}");
        var company = await _companyRepository.Get(updateCompanyInfoCommand.CompanyId);
        if (company is null)
            throw new NotFoundException(nameof(Entities.Company), updateCompanyInfoCommand.CompanyId);

        _mapper.Map(updateCompanyInfoCommand, company);
        _companyRepository.Update(company);
        await _companyRepository.SaveChangesAsync();
    }

    public async Task DeleteCompany(Guid companyId)
    {
        _logger.LogInformation($"Deleting company {companyId}");
        var exists = await _companyRepository.Remove(companyId);
        if (!exists)
            throw new NotFoundException(nameof(Entities.Company), companyId);

        await _companyRepository.SaveChangesAsync();
    }
}