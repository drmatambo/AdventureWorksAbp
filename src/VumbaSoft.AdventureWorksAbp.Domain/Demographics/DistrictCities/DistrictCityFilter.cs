using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities
{
    public class DistrictCityFilter
    {
        public Guid? CountryId { get; set; }

        public Guid? StateProvinceId { get; set; }

        public String? Name { get; set; }

        public Int64? Population { get; set; }

        public String? StateProvinceCode { get; set; }

        public String? CountryCode { get; set; }

        public Decimal? Latitude { get; set; }

        public Decimal? Longitude { get; set; }

        public String? Remarks { get; set; }
    }
}
