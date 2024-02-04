using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Continents.Continent;

public class IndexModel : AdventureWorksAbpPageModel
{
    public ContinentFilterInput ContinentFilter { get; set; }
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class ContinentFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "ContinentName")]
    public String? Name { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "ContinentPopulation")]
    public Int64? Population { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "ContinentRemarks")]
    public String? Remarks { get; set; }
}
