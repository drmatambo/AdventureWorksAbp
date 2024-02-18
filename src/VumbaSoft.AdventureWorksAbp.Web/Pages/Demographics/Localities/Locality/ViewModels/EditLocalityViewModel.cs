using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Localities.Locality.ViewModels;

public class EditLocalityViewModel
{
    //[DisabledInput]
    //[Display(Name = "LocalityContinentId")]
    //[SelectItems(nameof(EditModalModel.Continents))]
    //public Guid ContinentId { get; set; }

    //[DisabledInput]
    //[Display(Name = "LocalitySubcontinentId")]
    //[SelectItems(nameof(EditModalModel.SubContinents))]
    //public Guid SubcontinentId { get; set; }

    //[DisabledInput]
    //[Display(Name = "LocalityCountryId")]
    //[SelectItems(nameof(EditModalModel.Countries))]
    //public Guid CountryId { get; set; }

    //[DisabledInput]
    //[Display(Name = "LocalityRegionId")]
    //[SelectItems(nameof(EditModalModel.Regions))]
    //public Guid RegionId { get; set; }

    //[DisabledInput]
    //[Display(Name = "LocalityStateProvinceId")]
    //[SelectItems(nameof(EditModalModel.StateProvinces))]
    //public Guid StateProvinceId { get; set; }

    //[DisabledInput]
    //[Display(Name = "LocalityDistrictCityId")]
    //[SelectItems(nameof(EditModalModel.DistrictCities))]
    //public Guid DistrictCityId { get; set; }

    [DisabledInput]
    [Display(Name = "Continent Name")]
    public String ContinentName { get; set; }

    [DisabledInput]
    [Display(Name = "Subcontinent Name")]
    public String SubcontinentName { get; set; }

    [DisabledInput]
    [Display(Name = "CountryName")]
    public String CountryName { get; set; }

    [DisabledInput]
    [Display(Name = "Region Name")]
    public String RegionName { get; set; }

    [DisabledInput]
    [Display(Name = "StateProvince Name")]
    public String StateProvinceName { get; set; }

    [DisabledInput]
    [Display(Name = "DistrictCity Name")]
    public String DistrictCityName { get; set; }

    [Display(Name = "LocalityName")]
    public String Name { get; set; }

    [Display(Name = "LocalityPopulation")]
    public Int64 Population { get; set; }

    [Display(Name = "LocalityDistrictCityCode")]
    public String DistrictCityCode { get; set; }

    [Display(Name = "LocalityLocalityCode")]
    public String LocalityCode { get; set; }

    [Display(Name = "LocalityLatitude")]
    public Decimal Latitude { get; set; }

    [Display(Name = "LocalityLongitude")]
    public Decimal Longitude { get; set; }

    [TextArea]
    [Display(Name = "LocalityRemarks")]
    public String Remarks { get; set; }
}
