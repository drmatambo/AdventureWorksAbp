using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Localities.Locality;

public class IndexModel : AdventureWorksAbpPageModel
{
    public LocalityFilterInput LocalityFilter { get; set; }
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class LocalityFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "LocalityContinentId")]
    public Guid? ContinentId { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "LocalitySubcontinentId")]
    public Guid? SubcontinentId { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "LocalityCountryId")]
    public Guid? CountryId { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "LocalityRegionId")]
    public Guid? RegionId { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "LocalityStateProvinceId")]
    public Guid? StateProvinceId { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "LocalityDistrictCityId")]
    public Guid? DistrictCityId { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "LocalityName")]
    public String? Name { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "LocalityPopulation")]
    public Int64? Population { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "LocalityDistrictCityCode")]
    public String? DistrictCityCode { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "LocalityLocalityCode")]
    public String? LocalityCode { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "LocalityLatitude")]
    public Decimal? Latitude { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "LocalityLongitude")]
    public Decimal? Longitude { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "LocalityRemarks")]
    public String? Remarks { get; set; }
}
