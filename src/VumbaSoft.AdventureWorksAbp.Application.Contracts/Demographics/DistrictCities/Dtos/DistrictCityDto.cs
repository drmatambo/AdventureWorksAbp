using System;
using System.Collections.ObjectModel;
using Volo.Abp.Application.Dtos;
using VumbaSoft.AdventureWorksAbp.Demographics.Localities.Dtos;

namespace VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities.Dtos;

[Serializable]
public class DistrictCityDto : FullAuditedEntityDto<Guid>
{
    public Guid CountryId { get; set; }

    public Guid StateProvinceId { get; set; }

    public String Name { get; set; }

    public Int64 Population { get; set; }

    public String StateProvinceCode { get; set; }

    public String CountryCode { get; set; }

    public Decimal Latitude { get; set; }

    public Decimal Longitude { get; set; }

    public String Remarks { get; set; }

    public Collection<CreateLocalityDto> Localities { get; set; } = new();
}