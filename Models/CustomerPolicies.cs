using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace insuranceCompany.Models
{
    public class CustomerPolicies
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? PoliciesId { get; set; }
    }
}
