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

            return context.Customers.FromSqlRaw(statement);
        }

        [HttpPost, Route("customers"), Authorize(Policies.CREATE_CUSTOMER)]
        public async Task<IActionResult> Post([FromBody]Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Customers.Add(customer);
                    await context.SaveChangesAsync();

                    return Ok(customer);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        [HttpPut, Route("customers/{id:int}"), Authorize(Policies.UPDATE_CUSTOMERS)]
        public async Task<IActionResult> Post([FromRoute]int id, [FromBody]Customer customer)
        {
            try
            {
                var existing = context.Customers.Find(id);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else if (id != customer.Id || existing == null)                
                {
                    return NotFound(customer);
                }
                else
                {
                    existing.FirstName = customer.FirstName;
                    existing.LastName = customer.LastName;

                    await context.SaveChangesAsync();

                    return Ok(customer);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
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