using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using insuranceCompany.Data;
using insuranceCompany.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace insuranceCompany.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        ICustomersRepository _customersRepo;

        public CustomerController(ICustomersRepository customersRepo, ILogger<CustomerController> logger)
        {
            _customersRepo = customersRepo;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customersRepo.GetCustomers();
        }
    }
}
