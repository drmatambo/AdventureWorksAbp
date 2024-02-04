using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Regions.Region.ViewModels;

public class CreateRegionViewModel
{
    [Display(Name = "RegionName")]
    public String Name { get; set; }

    [Display(Name = "RegionPopulation")]
    public Int64 Population { get; set; }

    [Display(Name = "RegionCountryId")]
    public Guid CountryId { get; set; }

    [Display(Name = "RegionCountryCode")]
    public String CountryCode { get; set; }

    [Display(Name = "RegionRegionCode")]
    public String RegionCode { get; set; }

    [Display(Name = "RegionRemarks")]
    public String Remarks { get; set; }
}
