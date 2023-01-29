namespace Api.Middleware
{
    public class FirstMiddleware
    {
        private readonly RequestDelegate _next;

        public FirstMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Query.ContainsKey("AddText"))
            {
                await context.Response.WriteAsync("First Middleware Executing. \n");
            }
            await _next(context);
            if (context.Request.Query.ContainsKey("AddText"))
            {
                await context.Response.WriteAsync("First Middleware Executed. \n");
            }
        }
    }
}
