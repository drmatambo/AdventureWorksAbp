using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Countries.Dtos
{
    public class CountryContinentLookUpDto : EntityDto<Guid>
    { 
        public string Name { get; set; }
    }

}
