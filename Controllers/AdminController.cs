using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_Example.Data;
using CRM_Example.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AdminController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet, Route("customers"), Authorize(Policies.VIEW_CUSTOMERS)]
        public IEnumerable<Customer> Get([FromQuery]string filter, [FromQuery]string column, [FromQuery]int page, [FromQuery]int pageCount)
        {
            (filter, column, page, pageCount) = SetDefaultsIfValuesNotProvided(filter, column, page, pageCount);

            var filterText = filter == null || filter == "null" ? "@filter=null" : $"@filter='{filter}'";

            var statement = $"GetCustomers {filterText}, @page={page}, @pageCount={pageCount}, @column='{column}'";

            var results = context.Customers.FromSqlRaw(statement);

            return results.ToList();
        }

        private static (string filter, string column, int page, int pageCount) SetDefaultsIfValuesNotProvided(string filter, string column, int page, int pageCount)
        {
            if (page <= 0)
            {
                page = 1;
            }

            if (pageCount <= 0)
            {
                pageCount = 10;
            }

            if (string.IsNullOrEmpty(column))
            {
                column = "FirstName";
            }

            return (filter, column, page, pageCount);
        }
    }
}