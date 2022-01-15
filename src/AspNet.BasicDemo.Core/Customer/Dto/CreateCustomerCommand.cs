namespace AspNet.BasicDemo.Core.Customer.Dto;

public class CreateCustomerCommand : IMapFrom
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Guid CompanyId { get; set; }

    public void Map(Profile profile)
    {
        profile.CreateMap<CreateCustomerCommand, Entities.Customer>()
            .ForMember(customer => customer.Name, expression => expression.MapFrom(command => command.Name))
            .ForMember(customer => customer.Address, expression => expression.MapFrom(command => command.Address))
            .ForMember(customer => customer.Email, expression => expression.MapFrom(command => command.Email))
            .ForMember(customer => customer.Phone, expression => expression.MapFrom(command => command.Phone))
            .ForMember(customer => customer.CompanyId, expression => expression.MapFrom(command => command.CompanyId));
    }
}