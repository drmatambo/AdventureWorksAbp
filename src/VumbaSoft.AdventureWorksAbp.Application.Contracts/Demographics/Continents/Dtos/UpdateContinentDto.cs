using System;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Continents.Dtos;

[Serializable]
public class UpdateContinentDto
{
    public String Name { get; set; }

    public Int64 Population { get; set; }

    public String Remarks { get; set; }
}