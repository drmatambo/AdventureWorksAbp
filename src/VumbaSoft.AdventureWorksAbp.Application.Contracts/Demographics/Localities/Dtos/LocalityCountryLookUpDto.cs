using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Localities.Dtos
{
    public class LocalityCountryLookUpDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
