using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities.Dtos
{
    public class DistrictCityRegionLookUpDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
