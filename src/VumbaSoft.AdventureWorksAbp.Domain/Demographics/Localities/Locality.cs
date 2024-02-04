using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Localities;

public class Locality : FullAuditedAggregateRoot<Guid>
{
    public virtual Guid ContinentId { get; set; }
    public virtual Guid SubcontinentId { get; set; }
    public virtual Guid CountryId { get; set; }
    public virtual Guid RegionId { get; set; }
    public virtual Guid StateProvinceId { get; set; }
    public virtual Guid DistrictCityId { get; set; }
    public virtual String Name { get; set; }
    public virtual Int64 Population { get; set; }
    public virtual String DistrictCityCode { get; set; }
    public virtual String LocalityCode { get; set; }
    public virtual Decimal Latitude { get; set; }
    public virtual Decimal Longitude { get; set; }
    //public virtual DistrictCity DistrictCity { get; set; } //Navigation property
    //public virtual ICollection<StateProvince>StateProvinces { get; set; }
    public virtual String Remarks { get; set; }


    protected Locality()
    {
    }

    public Locality(
        Guid id,
        Guid continentId,
        Guid subcontinentId,
        Guid countryId,
        Guid regionId,
        Guid stateProvinceId,
        Guid districtCityId,
        String name,
        Int64 population,
        String districtCityCode,
        String localityCode,
        Decimal latitude,
        Decimal longitude,
        String remarks
    ) : base(id)
    {
        ContinentId = continentId;
        SubcontinentId = subcontinentId;
        CountryId = countryId;
        RegionId = regionId;
        StateProvinceId = stateProvinceId;
        DistrictCityId = districtCityId;
        Name = name;
        Population = population;
        DistrictCityCode = districtCityCode;
        LocalityCode = localityCode;
        Latitude = latitude;
        Longitude = longitude;
        Remarks = remarks;
    }
}
