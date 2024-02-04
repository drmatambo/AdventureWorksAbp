using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Localities.Locality.ViewModels;

public class EditLocalityViewModel
{
    [Display(Name = "LocalityContinentId")]
    public Guid ContinentId { get; set; }

    [Display(Name = "LocalitySubcontinentId")]
    public Guid SubcontinentId { get; set; }

    [Display(Name = "LocalityCountryId")]
    public Guid CountryId { get; set; }

    [Display(Name = "LocalityRegionId")]
    public Guid RegionId { get; set; }

    [Display(Name = "LocalityStateProvinceId")]
    public Guid StateProvinceId { get; set; }

    [Display(Name = "LocalityDistrictCityId")]
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

    [Display(Name = "LocalityRemarks")]
    public String Remarks { get; set; }
}
