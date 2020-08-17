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

        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return _customersRepo.GetCustomer(id);
        }

        [HttpPost()]
        public ActionResult AddCustomer([FromBody] Customer customer)
        {
            try
            {
                var status = _customersRepo.AddCustomer(customer);
                return Ok();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, [FromBody] Customer customer)
        {
            try
            {
                var status = _customersRepo.UpdateCustomer(customer);
                return Ok();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            try
            {
                var status = _customersRepo.DeleteCustomer(id);
                return Ok();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest();
            }
        }
    }
}
