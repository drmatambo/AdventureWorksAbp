using System;
using System.Collections.ObjectModel;
using Volo.Abp.Application.Dtos;
using VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities.Dtos;

namespace VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces.Dtos;

[Serializable]
public class StateProvinceDto : FullAuditedEntityDto<Guid>
{
    public Guid CountryId { get; set; }
    public String CountryName { get; set; }

    public Guid RegionId { get; set; }
    public String RegionName { get; set; }

    public String Name { get; set; }

    public Int64 Population { get; set; }

    public String RegionCode { get; set; }

    public String StateProvinceCode { get; set; }

    public String Remarks { get; set; }

    public Collection<CreateDistrictCityDto> DistrictCities { get; set; } = new();
}