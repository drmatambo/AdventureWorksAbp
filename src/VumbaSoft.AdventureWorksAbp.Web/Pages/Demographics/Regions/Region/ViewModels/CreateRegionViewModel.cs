using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Regions.Region.ViewModels;

public class CreateRegionViewModel
{
    [SelectItems(nameof(CreateModalModel.RegionContinents))]
    [Display(Name = "Continent")]
    public Guid ContinentId { get; set; }

    [SelectItems(nameof(CreateModalModel.RegionSubContinents))]
    [Display(Name = "Sbcontinent")]
    public Guid SubContinentId { get; set; }

    [SelectItems(nameof(CreateModalModel.RegionCountries))]
    [Display(Name = "Country")]
    public Guid CountryId { get; set; }

    [Display(Name = "Region Name")]
    public String Name { get; set; }

    [Display(Name = "Population")]
    public Int64 Population { get; set; }

    [Display(Name = "Country Code")]
    public String CountryCode { get; set; }

    [Display(Name = "RegionRegionCode")]
    public String RegionCode { get; set; }

    [TextArea]
    [Display(Name = "RegionRemarks")]
    public String Remarks { get; set; }
}
