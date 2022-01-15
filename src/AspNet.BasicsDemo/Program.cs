namespace AspNet.BasicsDemo;

public static class Program
{
    private static void Main(string[] args)
    {
        var host = CreateHostBuilder(args)
            .Build();
        host.Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup(typeof(Startup)); });
}