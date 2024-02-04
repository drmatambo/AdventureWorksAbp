using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Regions.Region;

public class IndexModel : AdventureWorksAbpPageModel
{
    public RegionFilterInput RegionFilter { get; set; }
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class RegionFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "RegionName")]
    public String? Name { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "RegionPopulation")]
    public Int64? Population { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "RegionCountryId")]
    public Guid? CountryId { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "RegionCountryCode")]
    public String? CountryCode { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "RegionRegionCode")]
    public String? RegionCode { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "RegionRemarks")]
    public String? Remarks { get; set; }
}
