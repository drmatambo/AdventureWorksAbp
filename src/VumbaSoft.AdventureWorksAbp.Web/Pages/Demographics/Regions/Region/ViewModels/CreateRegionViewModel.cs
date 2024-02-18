using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Regions.Region.ViewModels;

public class CreateRegionViewModel
{
    [SelectItems(nameof(CreateModalModel.RegionCountries))]
    [Display(Name = "RegionCountryId")]
    public Guid CountryId { get; set; }

    [Display(Name = "RegionName")]
    public String Name { get; set; }

    [Display(Name = "RegionPopulation")]
    public Int64 Population { get; set; }

    [Display(Name = "RegionCountryCode")]
    public String CountryCode { get; set; }

    [Display(Name = "RegionRegionCode")]
    public String RegionCode { get; set; }

    [TextArea]
    [Display(Name = "RegionRemarks")]
    public String Remarks { get; set; }
}
