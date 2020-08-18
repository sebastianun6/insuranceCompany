using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using insuranceCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace insuranceCompany.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Policy> Policies { get; set; }

        public DbSet<CustomerPolicies> CustomerPolicies { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
