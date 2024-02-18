using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Subcontinents.Subcontinent.ViewModels;

public class CreateSubcontinentViewModel
{
    [SelectItems(nameof(CreateModalModel.Continents))]
    [Display(Name = "SubcontinentName")]
    public Guid ContinentId { get; set; }

    [Display(Name = "SubcontinentName")]
    public String Name { get; set; }

    [Display(Name = "SubcontinentPopulation")]
    public Int64 Population { get; set; }

    [TextArea]
    [Display(Name = "SubcontinentRemarks")]
    public String Remarks { get; set; }
}
