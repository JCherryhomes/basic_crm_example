using CRM_Example.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Example.Models
{
    public class SampleDataMiddleware : IMiddleware
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ApplicationDbContext dbContext;

        public SampleDataMiddleware(IServiceProvider serviceProvider, ApplicationDbContext dbContext)
        {
            this.serviceProvider = serviceProvider;
            this.dbContext = dbContext;
        }

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            SampleData.Initialize(serviceProvider, dbContext).Wait();
            return next.Invoke(context);
        }
    }
}
