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
    }
}
