using System;
using System.Collections.ObjectModel;
using Volo.Abp.Application.Dtos;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Continents.Dtos;

[Serializable]
public class ContinentDto : FullAuditedEntityDto<Guid>
{
    public String Name { get; set; }

    public Int64 Population { get; set; }

    public String Remarks { get; set; }

    public Collection<CreateContinentDto> Subcontinents { get; set; } = new();
}