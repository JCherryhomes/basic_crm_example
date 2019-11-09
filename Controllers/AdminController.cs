using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_Example.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AdminController(ApplicationDbContext context) => this.context = context;
    }
}