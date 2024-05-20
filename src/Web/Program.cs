using CleanArchitecture.Infrastructure.Data;
using Serilog;

try
{
    var licensePath = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location)?.FullName + "/clidriver/license/db2consv_ee.lic";
    if (!File.Exists(licensePath))
    {
        File.Copy("/db2/license/db2consv_ee.lic", licensePath);
    }

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddApplicationServices();
    builder.Services.AddInfrastructureServices(builder.Configuration);
    builder.Services.AddWebServices();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        // await app.InitialiseDatabaseAsync();
    }
    else
    {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHealthChecks("/health");
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseReDoc(settings =>
    {
        settings.DocumentPath = "/api/specification.json";
        settings.Path = "/docs";
    });

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");

    app.MapRazorPages();

    app.MapFallbackToFile("index.html");

    app.UseExceptionHandler(options => { });


    app.Map("/", () => Results.Redirect("/api"));

    app.MapEndpoints();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, $"Unhandled exception: ${ex.InnerException?.Message}");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}


public partial class Program { }
