using BlogZamin.Core.Contract.Categories.Commands;
using BlogZamin.Core.Contract.Categories.Queries;
using BlogZamin.Infrastructure.SQL.Commands.Categories;
using BlogZamin.Infrastructure.SQL.Commands.Common;
using BlogZamin.Infrastructure.SQL.Queries.Categories;
using BlogZamin.Infrastructure.SQL.Queries.Common;
using BlogZamin.Service.Grpc.Interceptors;
using BlogZamin.Service.Grpc.Providers;
using BlogZamin.Service.Grpc.Services.V1.Categories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ICategoryCommandRepository,CategoryCommandRepository>();
builder.Services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
builder.Services.AddDbContext<BlogZaminCommandDbContext>();
builder.Services.AddDbContext<BlogZaminQueryDbContext>();
builder.Services.AddGrpcReflection();
builder.Services.AddSingleton<ProtoFileProvider>();
builder.Services.AddGrpc(c=>
{
    c.EnableDetailedErrors= true;
    c.Interceptors.Add<ExceptionInterceptor>();
}
);

var app = builder.Build();
app.MapGrpcReflectionService();
// Configure the HTTP request pipeline.
app.MapGrpcService<CategoryQueryService>();
app.MapGrpcService<CategoryCommandService>();

app.MapGet("/protos", (ProtoFileProvider protoFileProvider) =>
{
    return Results.Ok(protoFileProvider.GetAll());
});
app.MapGet("/protos/v{version:int}/{protoName}", (ProtoFileProvider protoFileProvider, int version, string protoName) =>
{
    string filePath = protoFileProvider.GetPath(version, protoName);
    if (string.IsNullOrEmpty(filePath))
        return Results.NotFound();
    return Results.File(filePath);
});

app.MapGet("/protos/v{version:int}/{protoName}/view", async (ProtoFileProvider protoFileProvider, int version, string protoName) =>
{
    string fileContent = await protoFileProvider.GetContent(version, protoName);
    if (string.IsNullOrEmpty(fileContent))
        return Results.NotFound();
    return Results.Text(fileContent);
});
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
