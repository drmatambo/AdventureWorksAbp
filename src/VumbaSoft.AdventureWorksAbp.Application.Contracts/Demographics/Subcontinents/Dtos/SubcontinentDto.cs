using System;
using System.Collections.ObjectModel;
using Volo.Abp.Application.Dtos;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries.Dtos;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents.Dtos;

[Serializable]
public class SubcontinentDto : FullAuditedEntityDto<Guid>
{
    public String Name { get; set; }

    public Guid ContinentId { get; set; }

    public Int64 Population { get; set; }

    public String Remarks { get; set; }

    public Collection<CreateCountryDto> Countries { get; set; } = new();
}