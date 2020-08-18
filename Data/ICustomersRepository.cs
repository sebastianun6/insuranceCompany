using insuranceCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insuranceCompany.Data
{
    public interface ICustomersRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int id);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(int id);
        bool AddCustomer(Customer customer);
        bool AssignPolicy(int customerId, int policyId);
        bool RemovePolicy(int customerId, int policyId);
    }
}
