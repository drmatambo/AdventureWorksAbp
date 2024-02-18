using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Regions.Region.ViewModels;

public class EditRegionViewModel
{
    //[DisabledInput]
    //[Display(Name = "Region Country Id")]
    //[SelectItems(nameof(EditModalModel.RegionCountries))]
    //public Guid CountryId { get; set; }

    [DisabledInput]
    [Display(Name = "Region Country Name")]
    public String RegionCountryName { get; set; }

    [Display(Name = "Region Name")]
    public String Name { get; set; }

    [Display(Name = "Region Population")]
    public Int64 Population { get; set; }

    [Display(Name = "Region Country Code")]
    public String CountryCode { get; set; }

    [Display(Name = "Region Region Code")]
    public String RegionCode { get; set; }

    [TextArea]
    [Display(Name = "Region Remarks")]
    public String Remarks { get; set; }
}
