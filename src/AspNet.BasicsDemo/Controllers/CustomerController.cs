namespace AspNet.BasicsDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public Task<IEnumerable<CustomerViewModel>> Get() => _customerService.GetAllCustomers();

    [HttpGet("{id:guid}")]
    public Task<CustomerViewModel> GetById(Guid id) => _customerService.GetCustomerById(id);

    [HttpPost]
    public Task<CustomerViewModel> Post(CreateCustomerCommand command) => _customerService.CreateCustomer(command);

    [HttpPatch]
    public Task<CustomerViewModel> Patch(UpdateCustomerInfoCommand command) => _customerService.UpdateCustomer(command);

    [HttpDelete("{id:guid}")]
    public Task Delete(Guid id) => _customerService.DeleteCustomer(id);
}