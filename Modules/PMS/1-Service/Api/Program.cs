using Api.Extensions;
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
var app = builder.ConfigureServices().ConfigurePipeLines();
app.Run();
