namespace AspNet.BasicDemo.Core.Company.Dto;

public class CreateCompanyCommand : IMapFrom
{
    public string Name { get; set; }
    public string Website { get; set; }

    public void Map(Profile profile)
    {
        profile.CreateMap<CreateCompanyCommand, Entities.Company>()
            .ForMember(company => company.Name, expression => expression.MapFrom(command => command.Name))
            .ForMember(company => company.Website, expression => expression.MapFrom(command => command.Website))
            .ReverseMap();
    }
}