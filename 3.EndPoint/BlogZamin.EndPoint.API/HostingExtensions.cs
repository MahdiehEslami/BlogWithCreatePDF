using BlogZamin.Infrastructure.SQL.Commands.Common;
using BlogZamin.Infrastructure.SQL.Queries.Common;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Extensions.DependencyInjection;
using Zamin.Infra.Data.Sql.Commands.Interceptors;

namespace BlogZamin.EndPoint.API
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder) 
        {
            string cnn = "Server=.;Database=BlogZamin;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False";
            builder.Services.AddZaminParrotTranslator(c =>
            {
                c.ConnectionString = cnn;
                c.AutoCreateSqlTable = true;
                c.SchemaName = "dbo";
                c.TableName = "ParrotTranslations";
                c.ReloadDataIntervalInMinuts = 1;
            });
            builder.Services.AddZaminApiCore("Zamin", "BlogZamin");
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddZaminWebUserInfoService(c => { c.DefaultUserId = "1"; }, true);

            builder.Services.AddZaminAutoMapperProfiles(option =>
            {
                option.AssmblyNamesForLoadProfiles = "BlogZamin";
            });

            builder.Services.AddZaminMicrosoftSerializer();

            builder.Services.AddZaminInMemoryCaching();

            builder.Services.AddDbContext<BlogZaminCommandDbContext>(c => c.UseSqlServer(cnn).AddInterceptors(new SetPersianYeKeInterceptor(), new AddAuditDataInterceptor()));
            builder.Services.AddDbContext<BlogZaminQueryDbContext>(c => c.UseSqlServer(cnn));


            builder.Services.AddSwaggerGen();

            return builder.Build();
        }
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseZaminApiExceptionHandler();
            app.UseDeveloperExceptionPage();
            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
