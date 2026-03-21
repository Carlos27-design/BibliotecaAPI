namespace BibliotecaAPI
{
    public class BloquearPeticionMiddleware
    {
        private readonly RequestDelegate next;

        public BloquearPeticionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if(context.Request.Path == "/bloqueado")
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Acceso denegado");
            }
            else
            {
                await next.Invoke(context);
            }
        }
    }

    public static class BloquearPeticionesMiddlewareExtension
    {
        public static IApplicationBuilder UseBloquearPeticion(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BloquearPeticionMiddleware>();
        }
    }
}
