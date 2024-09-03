using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.DistrictCities.DistrictCity.ViewModels;

public class CreateDistrictCityViewModel
{

    [SelectItems(nameof(CreateModalModel.DistrictCityContinents))]
    [Display(Name = "Continent")]
    public Guid ContinentId { get; set; }

    [SelectItems(nameof(CreateModalModel.DistrictCitySubcontinents))]
    [Display(Name = "Sbcontinent")]
    public Guid SubContinentId { get; set; }

    [Display(Name = "DistrictCityCountryId")]
    [SelectItems(nameof(CreateModalModel.DistrictCityCountries))]
    public Guid CountryId { get; set; }

    [Display(Name = "StateProvinceRegionId")]
    [SelectItems(nameof(CreateModalModel.DistrictCityRegions))]
    public Guid RegionId { get; set; }

    [Display(Name = "DistrictCityStateProvinceId")]
    [SelectItems(nameof(CreateModalModel.DistrictCityStateProvinces))]
    public Guid StateProvinceId { get; set; }

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
