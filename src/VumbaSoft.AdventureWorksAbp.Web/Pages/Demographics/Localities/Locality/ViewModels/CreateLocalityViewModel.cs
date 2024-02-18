using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Localities.Locality.ViewModels;

public class CreateLocalityViewModel
{
    [Display(Name = "LocalityContinentId")]
    [SelectItems(nameof(CreateModalModel.Continents))]
    public Guid ContinentId { get; set; }

    [Display(Name = "LocalitySubcontinentId")]
    [SelectItems(nameof(CreateModalModel.SubContinents))]
    public Guid SubcontinentId { get; set; }
        
    [Display(Name = "LocalityCountryId")]
    [SelectItems(nameof(CreateModalModel.Countries))]
    public Guid CountryId { get; set; }
        
    [Display(Name = "LocalityRegionId")]
    [SelectItems(nameof(CreateModalModel.Regions))]
    public Guid RegionId { get; set; }

    [Display(Name = "LocalityStateProvinceId")]
    [SelectItems(nameof(CreateModalModel.StateProvinces))]
    public Guid StateProvinceId { get; set; }

    [Display(Name = "LocalityDistrictCityId")]
    [SelectItems(nameof(CreateModalModel.DistrictCities))]
    public Guid DistrictCityId { get; set; }

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
