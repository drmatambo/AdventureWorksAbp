using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces.Dtos
{
    public class StateProvinceCountryLookUpDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
