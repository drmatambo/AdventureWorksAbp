using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.StateProvinces.StateProvince.ViewModels;

public class CreateStateProvinceViewModel
{
    [Display(Name = "StateProvinceCountryId")]
    [SelectItems(nameof(CreateModalModel.StateProvinceCountries))]
    public Guid CountryId { get; set; }

    [Display(Name = "StateProvinceRegionId")]
    [SelectItems(nameof(CreateModalModel.StateProvinceRegions))]
    public Guid RegionId { get; set; }

    [Display(Name = "StateProvinceName")]
    public String Name { get; set; }

    [Display(Name = "StateProvincePopulation")]
    public Int64 Population { get; set; }

    [Display(Name = "StateProvinceRegionCode")]
    public String RegionCode { get; set; }

    [Display(Name = "StateProvinceStateProvinceCode")]
    public String StateProvinceCode { get; set; }

    [TextArea]
    [Display(Name = "StateProvinceRemarks")]
    public String Remarks { get; set; }
}
