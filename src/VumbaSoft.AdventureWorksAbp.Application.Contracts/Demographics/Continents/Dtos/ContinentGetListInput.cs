using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Continents.Dtos;

[Serializable]
public class ContinentGetListInput : PagedAndSortedResultRequestDto
{
    public String? Name { get; set; }

    public Int64? Population { get; set; }

    public String? Remarks { get; set; }
}