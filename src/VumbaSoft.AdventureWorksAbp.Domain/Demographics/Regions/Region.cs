using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities.Auditing;
using VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Regions;

public class Region : FullAuditedAggregateRoot<Guid>
{
    public virtual String Name { get; set; }
    public virtual Int64 Population { get; set; }
    public virtual Guid CountryId { get; set; }
    public virtual String CountryCode { get; set; }
    public virtual String RegionCode { get; set; }
    //public virtual Country Country { get; set; } //Navigation property
    public virtual ICollection<StateProvince> StateProvinces { get; set; }
    public virtual String Remarks { get; set; }


    protected Region()
    {
    }

    public Region(
        Guid id,
        String name,
        Int64 population,
        Guid countryId,
        String countryCode,
        String regionCode,
        String remarks
    ) : base(id)
    {
        Name = name;
        Population = population;
        CountryId = countryId;
        CountryCode = countryCode;
        RegionCode = regionCode;
        Remarks = remarks;
        StateProvinces = new Collection<StateProvince>();

    }
}
