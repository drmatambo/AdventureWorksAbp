using System;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents.Dtos;

[Serializable]
public class CreateSubcontinentDto
{
    public String Name { get; set; }

    public Guid ContinentId { get; set; }

    public Int64 Population { get; set; }

    public String Remarks { get; set; }
}