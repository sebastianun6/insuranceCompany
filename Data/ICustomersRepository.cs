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
    }
}
