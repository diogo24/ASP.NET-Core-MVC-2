using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter14_ConfiguringApps.Infrastructure
{
    public class ContentMiddleware
    {
        private RequestDelegate _nextDelegate;
        private readonly UptimeService _uptimeService;

        public ContentMiddleware(RequestDelegate requestDelegate, UptimeService uptimeService)
        {
            _nextDelegate  = requestDelegate;
            _uptimeService = uptimeService;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLower() == "/middleware")
            {
                await httpContext.Response.WriteAsync("This is from the content middleware" + 
                    $"(uptime: {_uptimeService.Uptime}ms)", Encoding.UTF8);
            }
            else
            {
                await _nextDelegate.Invoke(httpContext);
            }
        }
    }
}
