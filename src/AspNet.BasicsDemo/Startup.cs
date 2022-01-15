namespace AspNet.BasicsDemo;

public class Startup
{
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
    {
        _configuration = configuration;
        _webHostEnvironment = webHostEnvironment;
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(options => options.Filters.Add<ApiExceptionFilterAttribute>());
        services.AddBasicDemoCore();
        services.AddInfrastructure(_configuration);
        services.AddOpenApiDocument(settings =>
        {
            settings.Title = "AspNet.BasicDemos";
            settings.Version = "1.1";
        });
    }

    public void Configure(IApplicationBuilder app)
    {
        if (_webHostEnvironment.IsDevelopment()) app.UseDeveloperExceptionPage();

        app.UseOpenApi();
        app.UseSwaggerUi3(settings => settings.Path = "/swagger");
        app.UseReDoc(settings => settings.Path = "/reDoc");

        app.UseRouting();
        app.UseEndpoints(builder => { builder.MapControllers(); });
    }
}