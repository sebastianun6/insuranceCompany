using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insuranceCompany.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _Context;
        private readonly ILogger _Logger;

        public CustomerRepository(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _Context = context;
            _Logger = loggerFactory.CreateLogger("CustomerRepository");
        }
    }
}
