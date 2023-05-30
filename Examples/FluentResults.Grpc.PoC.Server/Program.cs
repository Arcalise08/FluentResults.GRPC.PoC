using ProtoBuf.Grpc.Server;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
builder.Services.AddCodeFirstGrpc();
services.AddGrpc(x =>
{
    x.EnableDetailedErrors = true;

});
services.AddMvc();

var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGrpcService<HomeService>();
});
app.Run();
