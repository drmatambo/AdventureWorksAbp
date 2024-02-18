using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents.Dtos
{
    public class ContinentLookUpDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
