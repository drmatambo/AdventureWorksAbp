using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities.Auditing;
using VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities;

namespace VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces;

public class StateProvince : FullAuditedAggregateRoot<Guid>
{
    public virtual Guid CountryId { get; set; }
    public virtual Guid RegionId { get; set; }
    public virtual String Name { get; set; }
    public virtual Int64 Population { get; set; }
    public virtual String RegionCode { get; set; }
    public virtual String StateProvinceCode { get; set; }
    //public virtual Region Region { get; set; } //Navigation property
    public virtual ICollection<DistrictCity> DistrictCities { get; set; }
    public virtual String Remarks { get; set; }


    protected StateProvince()
    {
    }

    public StateProvince(
        Guid id,
        Guid countryId,
        Guid regionId,
        String name,
        Int64 population,
        String regionCode,
        String stateProvinceCode,
        String remarks
    ) : base(id)
    {
        CountryId = countryId;
        RegionId = regionId;
        Name = name;
        Population = population;
        RegionCode = regionCode;
        StateProvinceCode = stateProvinceCode;
        Remarks = remarks;
        DistrictCities = new Collection<DistrictCity>();
    }
}

