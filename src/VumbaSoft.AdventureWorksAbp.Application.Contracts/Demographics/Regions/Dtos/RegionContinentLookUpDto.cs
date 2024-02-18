using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Regions.Dtos
{
    public class RegionContinentLookUpDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
