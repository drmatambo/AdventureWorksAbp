using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Regions
{
    public class RegionFilter
    {
        public Guid? CountryId { get; set; }

        public String? Name { get; set; }

        public Int64? Population { get; set; }

        public String? CountryCode { get; set; }

        public String? RegionCode { get; set; }

        public String? Remarks { get; set; }
    }
}
