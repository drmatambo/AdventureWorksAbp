using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Countries.Country;

public class IndexModel : AdventureWorksAbpPageModel
{
    public CountryFilterInput CountryFilter { get; set; }
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class CountryFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "CountryContinentId")]
    public Guid? ContinentId { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "CountrySubcontinentId")]
    public Guid? SubcontinentId { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "CountryName")]
    public String? Name { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "CountryFormalName")]
    public String? FormalName { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "CountryNativeName")]
    public String? NativeName { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "CountryIsoTreeCode")]
    public String? IsoTreeCode { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "CountryIsoTwoCode")]
    public String? IsoTwoCode { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "CountryCcnTreeCode")]
    public String? CcnTreeCode { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "CountryPhoneCode")]
    public String? PhoneCode { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "CountryCapital")]
    public String? Capital { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "CountryCurrency")]
    public String? Currency { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "CountryPopulation")]
    public Int64? Population { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "CountryEmoji")]
    public String? Emoji { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "CountryEmojiU")]
    public String? EmojiU { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "CountryRemarks")]
    public String? Remarks { get; set; }
}
