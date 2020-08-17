using insuranceCompany.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insuranceCompany.Data
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly ApplicationDbContext _Context;
        private readonly ILogger _Logger;

        public CustomersRepository(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _Context = context;
            _Logger = loggerFactory.CreateLogger("CustomerRepository");
        }

        public Customer GetCustomer(int id)
        {
            return _Context.Customers.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _Context.Customers.ToList<Customer>();
        }

        public bool AddCustomer(Customer customer)
        {
            _Context.Add(customer);
            return _Context.SaveChanges() > 0 ? true : false;
        }

        public bool UpdateCustomer(Customer customer)
        {
            _Context.Customers.Attach(customer);
            _Context.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return _Context.SaveChanges() > 0 ? true : false;
        }

        public bool DeleteCustomer(int id)
        {
            var customer = _Context.Customers.SingleOrDefault(c => c.Id == id);
            _Context.Remove(customer);
            return _Context.SaveChanges() > 0 ? true : false;
        }
    }
}
