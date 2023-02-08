using Api.ConfigurationsExtensions;

namespace Api.Extensions;

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


        //TODO --> My PipeLine

        return app;
    }
}