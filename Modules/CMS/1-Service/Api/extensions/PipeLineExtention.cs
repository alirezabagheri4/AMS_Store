using Api.Configurations;
using Api.Middleware;

namespace Api.Extensions
{
    public static class PipeLineExtension
    {
        public static WebApplication ConfigurePipeLines(this WebApplication app)
        {
            //Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.UseSwaggerSetup();
            app.MapControllers();

            //My PipeLine
            app.Map("/admin", myApp =>
            {
                myApp.UseMiddleware<SecondMiddleware>();
            });

            app.Use(async (httpContext, next) =>
            {
                if (httpContext.Request.Query.ContainsKey("Id"))
                {
                    httpContext.Response.ContentType = "text/html";
                    await httpContext.Response.WriteAsync("Use Middleware ---> Key=Id - Received successfully");
                }
                if (httpContext.Request.Query.ContainsKey("Name"))
                {
                    httpContext.Response.ContentType = "text/html";
                    await httpContext.Response.WriteAsync("Use Middleware ---> Key=Name - Received successfully");
                  
                }
                await next();
            });

            app.UseMiddleware<FirstMiddleware>();

            app.MapGet("/", () => "Hello World!\n");

            return app;
        }
    }
}
