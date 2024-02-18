using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.DistrictCities.DistrictCity.ViewModels;

public class EditDistrictCityViewModel
{
    //[DisabledInput]
    //[Display(Name = "DistrictCityCountryId")]
    //[SelectItems(nameof(EditModalModel.Provinces))]
    //public Guid CountryId { get; set; }

    [DisabledInput]
    [Display(Name = "DistrictCityCountryName")]
    public String CountryName { get; set; }

    //[DisabledInput]
    //[Display(Name = "DistrictCityStateProvinceId")]
    //[SelectItems(nameof(EditModalModel.Provinces))]
    //public Guid StateProvinceId { get; set; }

    [DisabledInput]
    [Display(Name = "DistrictCityStateProvinceName")]
    public String StateProvinceName { get; set; }

    [Display(Name = "DistrictCityName")]
    public String Name { get; set; }

    [Display(Name = "DistrictCityPopulation")]
    public Int64 Population { get; set; }

    [Display(Name = "DistrictCityStateProvinceCode")]
    public String StateProvinceCode { get; set; }

    [Display(Name = "DistrictCityCountryCode")]
    public String CountryCode { get; set; }

    [Display(Name = "DistrictCityLatitude")]
    public Decimal Latitude { get; set; }

    [Display(Name = "DistrictCityLongitude")]
    public Decimal Longitude { get; set; }

    [TextArea]
    [Display(Name = "DistrictCityRemarks")]
    public String Remarks { get; set; }
}
