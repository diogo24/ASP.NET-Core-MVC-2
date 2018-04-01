using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter14_ConfiguringApps.Infrastructure
{
    public class BrowserTypeMiddleware
    {
        private readonly RequestDelegate _nextDelegate;

        public BrowserTypeMiddleware(RequestDelegate requestDelegate)
        {
            _nextDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Items["EdgeBrowser"] = httpContext.Request.Headers["User-Agent"].Any(v => v.ToLower().Contains("edge"));
            await _nextDelegate.Invoke(httpContext);
        }
    }
}
