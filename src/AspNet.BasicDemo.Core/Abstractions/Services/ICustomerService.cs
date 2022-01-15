namespace AspNet.BasicDemo.Core.Abstractions.Services;

public interface ICustomerService
{
    Task<IEnumerable<CustomerViewModel>> GetAllCustomers();
    Task<CustomerViewModel> GetCustomerById(Guid id);
    Task<CustomerViewModel> CreateCustomer(CreateCustomerCommand createCustomerCommand);
    Task<CustomerViewModel> UpdateCustomer(UpdateCustomerInfoCommand updateCustomerInfoCommand);
    Task DeleteCustomer(Guid customerId);
}