using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.StateProvinces.StateProvince;

public class IndexModel : AdventureWorksAbpPageModel
{
    public StateProvinceFilterInput StateProvinceFilter { get; set; }
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class StateProvinceFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "StateProvinceCountryId")]
    public Guid? CountryId { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "StateProvinceRegionId")]
    public Guid? RegionId { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "StateProvinceName")]
    public String? Name { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "StateProvincePopulation")]
    public Int64? Population { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "StateProvinceRegionCode")]
    public String? RegionCode { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "StateProvinceStateProvinceCode")]
    public String? StateProvinceCode { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "StateProvinceRemarks")]
    public String? Remarks { get; set; }
}
