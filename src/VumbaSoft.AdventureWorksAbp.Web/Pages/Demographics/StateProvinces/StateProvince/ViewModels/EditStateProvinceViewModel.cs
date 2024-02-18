using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.StateProvinces.StateProvince.ViewModels;

public class EditStateProvinceViewModel
{
    //[DisabledInput]
    //[Display(Name = "StateProvinceCountryId")]
    //[SelectItems(nameof(EditModalModel.StateProvinceCountries))]
    //public Guid CountryId { get; set; }

    [DisabledInput]
    [Display(Name = "Country Name")]
    public String CountryName { get; set; }

    //[DisabledInput]
    //[Display(Name = "StateProvinceRegionId")]
    //[SelectItems(nameof(EditModalModel.StateProvinceRegions))]
    //public Guid RegionId { get; set; }

    [DisabledInput]
    [Display(Name = "Region Name")]
    public String RegionName { get; set; }

    [Display(Name = "State Province Name")]
    public String Name { get; set; }

    [Display(Name = "State Province Population")]
    public Int64 Population { get; set; }

    [Display(Name = "State Province RegionCode")]
    public String RegionCode { get; set; }

    [Display(Name = "State Province State Province Code")]
    public String StateProvinceCode { get; set; }

    [TextArea]
    [Display(Name = "State Province Remarks")]
    public String Remarks { get; set; }
}
