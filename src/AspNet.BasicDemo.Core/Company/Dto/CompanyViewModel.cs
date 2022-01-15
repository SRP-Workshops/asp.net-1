namespace AspNet.BasicDemo.Core.Company.Dto;

public class CompanyViewModel : IMapFrom
{
    public string CompanyName { get; set; }
    public string CompanyWebSite { get; set; }
    public Guid CompanyId { get; set; }

    public void Map(Profile profile)
    {
        profile.CreateMap<Entities.Company, CompanyViewModel>()
            .ForMember(model => model.CompanyId, expression => expression.MapFrom(company => company.Id))
            .ForMember(model => model.CompanyName, expression => expression.MapFrom(company => company.Name))
            .ForMember(model => model.CompanyWebSite, expression => expression.MapFrom(company => company.Website));
    }
}