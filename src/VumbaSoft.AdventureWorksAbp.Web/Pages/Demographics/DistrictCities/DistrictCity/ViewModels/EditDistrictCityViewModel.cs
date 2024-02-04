using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.DistrictCities.DistrictCity.ViewModels;

public class EditDistrictCityViewModel
{
    [Display(Name = "DistrictCityCountryId")]
    public Guid CountryId { get; set; }

    [Display(Name = "DistrictCityStateProvinceId")]
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

    [Display(Name = "DistrictCityRemarks")]
    public String Remarks { get; set; }
}
