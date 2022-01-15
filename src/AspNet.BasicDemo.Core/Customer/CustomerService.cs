using AspNet.BasicDemo.Core.Exceptions;

namespace AspNet.BasicDemo.Core.Customer;

public class CustomerService : ICustomerService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, ICompanyRepository companyRepository, IMapper mapper,
        ILogger<CustomerService> logger)
    {
        _customerRepository = customerRepository;
        _companyRepository = companyRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IEnumerable<CustomerViewModel>> GetAllCustomers()
    {
        _logger.LogInformation("Getting all customers");
        var customers = await _customerRepository.GetAll();
        var customerViewModels = _mapper.Map<List<CustomerViewModel>>(customers);
        _logger.LogInformation($"{customers.Count} customers found");
        return customerViewModels;
    }

    public async Task<CustomerViewModel> GetCustomerById(Guid id)
    {
        _logger.LogInformation($"Getting customer with id {id}");
        var customer = await _customerRepository.Get(id);
        var customerViewModel = _mapper.Map<CustomerViewModel>(customer);
        return customerViewModel;
    }

    public async Task<CustomerViewModel> CreateCustomer(CreateCustomerCommand createCustomerCommand)
    {
        _logger.LogInformation($"Creating customer {createCustomerCommand.Name}");
        var company = await _companyRepository.Get(createCustomerCommand.CompanyId);
        if (company is null)
            throw new NotFoundException(nameof(Entities.Company), createCustomerCommand.CompanyId);

        var customer = _mapper.Map<Entities.Customer>(createCustomerCommand);
        _customerRepository.Add(customer);
        await _customerRepository.SaveChangesAsync();
        var customerViewModel = _mapper.Map<CustomerViewModel>(customer);
        return customerViewModel;
    }

    public async Task<CustomerViewModel> UpdateCustomer(UpdateCustomerInfoCommand updateCustomerInfoCommand)
    {
        var customer = await _customerRepository.Get(updateCustomerInfoCommand.CustomerId);
        if (customer is null)
            throw new NotFoundException(nameof(Entities.Customer), updateCustomerInfoCommand.CustomerId);

        _mapper.Map(updateCustomerInfoCommand, customer);
        await _customerRepository.SaveChangesAsync();
        var customerViewModel = _mapper.Map<CustomerViewModel>(customer);
        return customerViewModel;
    }

    public async Task DeleteCustomer(Guid customerId)
    {
        var exists = await _customerRepository.Remove(customerId);
        if (!exists)
            throw new NotFoundException(nameof(Entities.Customer), customerId);

        await _customerRepository.SaveChangesAsync();
    }
}