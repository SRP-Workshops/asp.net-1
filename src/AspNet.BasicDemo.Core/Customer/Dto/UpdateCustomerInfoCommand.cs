namespace AspNet.BasicDemo.Core.Customer.Dto;

public class UpdateCustomerInfoCommand : IMapFrom
{
    public Guid CustomerId { get; set; }
    public string NewName { get; set; }
    public string NewAddress { get; set; }
    public string NewEmail { get; set; }
    public string NewPhone { get; set; }

    public void Map(Profile profile)
    {
        profile.CreateMap<UpdateCustomerInfoCommand, Entities.Customer>()
            .ForMember(customer => customer.Name, expression => expression.MapFrom(command => command.NewName))
            .ForMember(customer => customer.Address, expression => expression.MapFrom(command => command.NewAddress))
            .ForMember(customer => customer.Email, expression => expression.MapFrom(command => command.NewEmail))
            .ForMember(customer => customer.Phone, expression => expression.MapFrom(command => command.NewPhone));
    }
}