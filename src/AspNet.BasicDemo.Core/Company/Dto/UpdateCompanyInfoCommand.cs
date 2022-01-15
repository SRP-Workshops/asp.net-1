namespace AspNet.BasicDemo.Core.Company.Dto;

public class UpdateCompanyInfoCommand : IMapFrom
{
    public Guid CompanyId { get; set; }
    public string NewName { get; set; }
    public string NewWebSite { get; set; }

    public void Map(Profile profile)
    {
        profile.CreateMap<UpdateCompanyInfoCommand, Entities.Company>()
            .ForMember(company => company.Name, expression => expression.MapFrom(command => command.NewName))
            .ForMember(company => company.Website, expression => expression.MapFrom(command => command.NewWebSite));
    }
}