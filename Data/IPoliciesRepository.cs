using insuranceCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insuranceCompany.Data
{
    public interface IPoliciesRepository
    {
        IEnumerable<Policy> GetPolicies();
        Policy GetPolicy(int id);
        bool UpdatePolicy(Policy policy);
        bool DeletePolicy(int id);
        bool AddPolicy(Policy policy);
    }
}
