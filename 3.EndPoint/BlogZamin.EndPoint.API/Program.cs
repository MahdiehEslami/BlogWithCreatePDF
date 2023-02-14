
using BlogZamin.EndPoint.API;
using Zamin.Extensions.DependencyInjection;
using Zamin.Utilities.SerilogRegistration.Extensions;

SerilogExtensions.RunWithSerilogExceptionHandling(() =>
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddCors();
    var app = builder.AddZaminSerilog(c =>
    {
        c.ApplicationName = "BlogZamin";
        c.ServiceName = "BlogZaminService";
        c.ServiceVersion = "1.0";
    }).ConfigureServices().ConfigurePipeline();
    app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
    //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBPh8sVXJ0S0d+XE9AcVRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS3xTckVkWXZbc3BQR2VUVQ==;ORg4AjUWIQA/Gnt2VVhhQlFaclhJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxRdkFjXn9XdXdRQ2FaWEA=;NRAiBiAaIQQuGjN/V0Z+XU9EaFtFVmJLYVB3WmpQdldgdVRMZVVbQX9PIiBoS35RdEVnWXheeXFWQmVdVkxy");

    app.Run();
});

