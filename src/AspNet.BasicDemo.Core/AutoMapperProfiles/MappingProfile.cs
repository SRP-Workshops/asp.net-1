namespace AspNet.BasicDemo.Core.AutoMapperProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        var mapFromTypes = Assembly.GetExecutingAssembly()
            .GetExportedTypes()
            .Where(type => type.GetInterfaces().Any(i => i == typeof(IMapFrom)));

        foreach (var mapFromType in mapFromTypes)
        {
            if (Activator.CreateInstance(mapFromType) is IMapFrom instance)
                instance.Map(this);
        }
    }
}