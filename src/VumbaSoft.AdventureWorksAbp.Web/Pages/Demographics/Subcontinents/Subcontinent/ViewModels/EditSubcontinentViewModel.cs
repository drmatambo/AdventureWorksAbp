using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Subcontinents.Subcontinent.ViewModels;

public class EditSubcontinentViewModel
{
    //[SelectItems(nameof(EditModalModel.Continents))]
    //[DisabledInput]
    //[Display(Name = "SubcontinentContinentId")]
    //public Guid ContinentId { get; set; }

    //TODO: Added Id property
    [HiddenInput]
    public Guid Id { get; set; }

    [DisabledInput]
    [Display(Name = "Continent Name")]
    public String ContinentName { get; set; }

    [Display(Name = "Subcontinent Name")]
    public String Name { get; set; }

    [Display(Name = "Subcontinent Population")]
    public Int64 Population { get; set; }

    [TextArea]
    [Display(Name = "Subcontinent Remarks")]
    public String Remarks { get; set; }
}
