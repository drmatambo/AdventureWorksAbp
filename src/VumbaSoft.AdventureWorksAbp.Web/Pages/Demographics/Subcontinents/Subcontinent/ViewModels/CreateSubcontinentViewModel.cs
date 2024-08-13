using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Subcontinents.Subcontinent.ViewModels;

public class CreateSubcontinentViewModel
{
    [SelectItems(nameof(CreateModalModel.Continents))]
    [Display(Name = "Continent Name")]
    public Guid ContinentId { get; set; }

    [Display(Name = "Subcontinent Name")]
    public String Name { get; set; }

    [Display(Name = "Subcontinent Population")]
    public Int64 Population { get; set; }

    [TextArea]
    [Display(Name = "Subcontinent Remarks")]
    public String Remarks { get; set; }
}
