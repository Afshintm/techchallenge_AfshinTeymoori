using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LetsBet.Api.Infrastructure
{
    public class MyMiddleware
    {
        private RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!string.IsNullOrWhiteSpace(context.Request.Query["hack"]))
            {
                await context.Response.WriteAsync("are you hacking?");
            }
            else await _next.Invoke(context);

            //calling other middlewares and then adding something to the response.
            //await _next.Invoke(context);
            //if (!string.IsNullOrWhiteSpace(context.Request.Query["hack"]))
            //{
            //    await context.Response.WriteAsync("are you hacking?");
            //}
        }
    }
}
