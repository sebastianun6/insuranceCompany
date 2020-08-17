using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insuranceCompany.Models
{
    public class Policy
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string TypePolicy { get; set; }
        int Coverage { get; set; }
        DateTime BeginDate { get; set; }
        int CoveragePeriod { get; set; }
        double PolicyCost { get; set; }
        string TypeRisk { get; set; }
    }
}
