using Api.Extensions;
using OtpNet;

var builder = WebApplication.CreateBuilder(args);
var app = builder.ConfigureServices().ConfigurePipeLines();
app.Run();
