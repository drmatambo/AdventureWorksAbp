using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Subcontinents.Subcontinent;

public class IndexModel : AdventureWorksAbpPageModel
{
    public SubcontinentFilterInput SubcontinentFilter { get; set; }
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class SubcontinentFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "SubcontinentName")]
    public String? Name { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "SubcontinentContinentId")]
    public Guid? ContinentId { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "SubcontinentPopulation")]
    public Int64? Population { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "SubcontinentRemarks")]
    public String? Remarks { get; set; }
}
