using insuranceCompany.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insuranceCompany.Data
{
    public class PoliciesRepository : IPoliciesRepository
    {
        private readonly ApplicationDbContext _Context;
        private readonly ILogger _Logger;

        public PoliciesRepository(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _Context = context;
            _Logger = loggerFactory.CreateLogger("PoliciesRepository");
        }

        public bool AddPolicy(Policy policy)
        {
            _Context.Add(policy);
            return _Context.SaveChanges() > 0 ? true : false;
        }

        public bool DeletePolicy(int id)
        {
            var policy = _Context.Policies.SingleOrDefault(p => p.Id == id);
            _Context.Remove(policy);
            return _Context.SaveChanges() > 0 ? true : false;
        }

        public IEnumerable<Policy> GetPolicies()
        {
            return _Context.Policies.ToList<Policy>();
        }

        public IEnumerable<Policy> GetPoliciesAssignedForCustomer(int id)
        {
            var query = from cp in _Context.CustomerPolicies
                        join p in _Context.Policies on cp.PoliciesId equals p.Id
                        where cp.CustomerId == id 
                        select p;
            return query.ToList();
        }

        public IEnumerable<Policy> GetPoliciesToAssignForCustomer(int id)
        {
            var policies = _Context.Policies.ToList<Policy>();
            var policiesAssigned = GetPoliciesAssignedForCustomer(id);

            return policies.Where(i => !policiesAssigned.Contains(i)).ToList();
        }

        public Policy GetPolicy(int id)
        {
            return _Context.Policies.SingleOrDefault(p => p.Id == id);
        }

        public bool UpdatePolicy(Policy policy)
        {
            _Context.Policies.Attach(policy);
            _Context.Entry(policy).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return _Context.SaveChanges() > 0 ? true : false;
        }
    }
}
