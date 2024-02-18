using System;
using System.Collections.ObjectModel;
using Volo.Abp.Application.Dtos;
using VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces.Dtos;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Regions.Dtos;

[Serializable]
public class RegionDto : FullAuditedEntityDto<Guid>
{
    public Guid CountryId { get; set; }

    public String RegionCountryName { get; set; }

    public String Name { get; set; }

    public Int64 Population { get; set; }

    public String CountryCode { get; set; }

    public String RegionCode { get; set; }

    public String Remarks { get; set; }

    public Collection<CreateStateProvinceDto> StateProvinces { get; set; } = new ();
}