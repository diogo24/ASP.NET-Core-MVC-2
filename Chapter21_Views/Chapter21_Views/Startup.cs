﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chapter21_Views.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;

namespace Chapter21_Views
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //services.Configure<MvcViewOptions>(options => {
            //    //options.ViewEngines.Clear();
            //    options.ViewEngines.Insert(0, new DebugDataViewEngine());
            //});
            services.Configure<RazorViewEngineOptions>(options => {
                options.ViewLocationExpanders.Add(new SimpleExpander());
                options.ViewLocationExpanders.Add(new ColorExpander());            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
