using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces
{
    public class StateProvinceFilter
    {
        public Guid? CountryId { get; set; }

        public Guid? RegionId { get; set; }

        public String? Name { get; set; }

        public Int64? Population { get; set; }

        public String? RegionCode { get; set; }

        public String? StateProvinceCode { get; set; }

        public String? Remarks { get; set; }
    }
}
