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
    public class PolicyController : ControllerBase
    {
        private readonly ILogger<PolicyController> _logger;
        IPoliciesRepository _policiesRepo;

        public PolicyController(IPoliciesRepository policiesRepo, ILogger<PolicyController> logger)
        {
            _policiesRepo = policiesRepo;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Policy> Get()
        {
            return _policiesRepo.GetPolicies();
        }

        [HttpGet("{id}")]
        public Policy Get(int id)
        {
            return _policiesRepo.GetPolicy(id);
        }

        [HttpGet("{id}")]
        [Route("policiesToAssignForCustomer/{id}")]
        public IEnumerable<Policy> GetPoliciesToAssignForCustomer(int id)
        {
            return _policiesRepo.GetPoliciesToAssignForCustomer(id);
        }

        [HttpGet("{id}")]
        [Route("policiesAssignedForCustomer/{id}")]
        public IEnumerable<Policy> GetPoliciesAssignedForCustomer(int id)
        {
            return _policiesRepo.GetPoliciesAssignedForCustomer(id);
        }

        [HttpPost()]
        public ActionResult AddPolicy([FromBody] Policy policy)
        {
            try
            {
                var status = _policiesRepo.AddPolicy(policy);
                return Ok();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePolicy(int id, [FromBody] Policy policy)
        {
            try
            {
                var status = _policiesRepo.UpdatePolicy(policy);
                return Ok();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePolicy(int id)
        {
            try
            {
                var status = _policiesRepo.DeletePolicy(id);
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
