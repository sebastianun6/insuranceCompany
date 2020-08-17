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
    }
}
