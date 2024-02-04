using System;

namespace VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces.Dtos;

[Serializable]
public class CreateStateProvinceDto
{
    public Guid CountryId { get; set; }

    public Guid RegionId { get; set; }

    public String Name { get; set; }

    public Int64 Population { get; set; }

    public String RegionCode { get; set; }

    public String StateProvinceCode { get; set; }

    public String Remarks { get; set; }
}