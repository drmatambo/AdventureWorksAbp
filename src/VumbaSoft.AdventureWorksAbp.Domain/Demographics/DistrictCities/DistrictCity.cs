using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities.Auditing;
using VumbaSoft.AdventureWorksAbp.Demographics.Localities;

namespace VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities;
public class DistrictCity : FullAuditedAggregateRoot<Guid>
{
    public virtual Guid CountryId { get; set; }
    public virtual Guid StateProvinceId { get; set; }
    public virtual String Name { get; set; }
    public virtual Int64 Population { get; set; }
    public virtual String StateProvinceCode { get; set; }
    public virtual String CountryCode { get; set; }
    public virtual Decimal Latitude { get; set; }
    public virtual Decimal Longitude { get; set; }
    //public virtual StateProvince StateProvince { get; set; } //Navigation property
    public virtual ICollection<Locality> Localities { get; set; }
    public virtual String Remarks { get; set; }


    protected DistrictCity()
    {
    }

    public DistrictCity(
        Guid id,
        Guid countryId,
        Guid stateProvinceId,
        String name,
        Int64 population,
        String stateProvinceCode,
        String countryCode,
        Decimal latitude,
        Decimal longitude,
        String remarks
    ) : base(id)
    {
        CountryId = countryId;
        StateProvinceId = stateProvinceId;
        Name = name;
        Population = population;
        StateProvinceCode = stateProvinceCode;
        CountryCode = countryCode;
        Latitude = latitude;
        Longitude = longitude;
        Remarks = remarks;
        Localities = new Collection<Locality>();
    }
}
