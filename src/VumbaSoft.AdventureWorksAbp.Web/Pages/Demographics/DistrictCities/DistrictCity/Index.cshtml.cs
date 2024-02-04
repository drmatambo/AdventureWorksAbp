using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.DistrictCities.DistrictCity;

public class IndexModel : AdventureWorksAbpPageModel
{
    public DistrictCityFilterInput DistrictCityFilter { get; set; }
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class DistrictCityFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "DistrictCityCountryId")]
    public Guid? CountryId { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "DistrictCityStateProvinceId")]
    public Guid? StateProvinceId { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "DistrictCityName")]
    public String? Name { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "DistrictCityPopulation")]
    public Int64? Population { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "DistrictCityStateProvinceCode")]
    public String? StateProvinceCode { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "DistrictCityCountryCode")]
    public String? CountryCode { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "DistrictCityLatitude")]
    public Decimal? Latitude { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "DistrictCityLongitude")]
    public Decimal? Longitude { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "DistrictCityRemarks")]
    public String? Remarks { get; set; }
}
