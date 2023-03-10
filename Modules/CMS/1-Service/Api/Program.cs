using Api.Extensions;
var builder = WebApplication.CreateBuilder(args);
var app = builder.ConfigureServices().ConfigurePipeLines();
app.Run();
