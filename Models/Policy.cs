using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insuranceCompany.Models
{
    public class Policy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TypePolicy { get; set; }
        public int Coverage { get; set; }
        public DateTime BeginDate { get; set; }
        public int CoveragePeriod { get; set; }
        public double PolicyCost { get; set; }
        public string TypeRisk { get; set; }
    }
}
