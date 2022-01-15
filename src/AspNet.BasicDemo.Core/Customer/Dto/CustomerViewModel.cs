namespace AspNet.BasicDemo.Core.Customer.Dto;

public class CustomerViewModel : IMapFrom
{
    public Guid CustomerId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public void Map(Profile profile)
    {
        profile.CreateMap<CustomerViewModel, Entities.Customer>()
            .ForMember(customer => customer.Address, expression => expression.MapFrom(model => model.Address))
            .ForMember(customer => customer.Email, expression => expression.MapFrom(model => model.Email))
            .ForMember(customer => customer.Name, expression => expression.MapFrom(model => model.Name))
            .ForMember(customer => customer.Phone, expression => expression.MapFrom(model => model.Phone))
            .ForMember(customer => customer.Id, expression => expression.MapFrom(model => model.CustomerId))
            .ReverseMap();
    }
}