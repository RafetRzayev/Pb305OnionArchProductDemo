namespace Pb305OnionArchProductDemo.API
{
    public class SimpleExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public SimpleExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log the incoming request
            Console.WriteLine($"Incoming Request: {context.Request.Method} {context.Request.Path}");
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
            // Log the outgoing response
            Console.WriteLine($"Outgoing Response: {context.Response.StatusCode}");
        }
    }
}
