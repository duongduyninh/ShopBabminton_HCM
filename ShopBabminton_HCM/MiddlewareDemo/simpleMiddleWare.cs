using System.Diagnostics;

namespace ShopBabminton_HCM.MiddlewareDemo
{
    public class simpleMiddleWare
    {
        private readonly RequestDelegate _next;

        public simpleMiddleWare(RequestDelegate next) 
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            await _next(context);

            stopwatch.Stop();
            var ProcessingTimeAPI  = stopwatch.ElapsedMilliseconds;

            var apiPath = context.Request.Path;
            Console.WriteLine($"Request to {apiPath} took {ProcessingTimeAPI}ms");
        }

    }
}
