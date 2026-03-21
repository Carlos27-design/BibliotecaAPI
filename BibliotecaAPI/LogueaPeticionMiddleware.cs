namespace BibliotecaAPI
{
    public class LogueaPeticionMiddleware
    {
        private readonly RequestDelegate next;

        public LogueaPeticionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync (HttpContext context)
        {
            //Esto es cuando viene la petición
            var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogInformation($"Petición: {context.Request.Method} {context.Request.Path}");

            await next.Invoke(context);
            //Esto es cuando se va la respuesta
            logger.LogInformation($"Respuesta: {context.Response.StatusCode}");
        }
    }

    public static class LogueaPeticionMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogueaPeticion(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogueaPeticionMiddleware>();
        }
    }
}
