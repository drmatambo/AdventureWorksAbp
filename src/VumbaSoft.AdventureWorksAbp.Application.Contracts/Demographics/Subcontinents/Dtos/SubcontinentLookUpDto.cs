using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents.Dtos
{
    public class SubcontinentLookUpDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
