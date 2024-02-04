using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Subcontinents.Subcontinent.ViewModels;

public class CreateSubcontinentViewModel
{
    [Display(Name = "SubcontinentName")]
    public String Name { get; set; }

    [Display(Name = "SubcontinentContinentId")]
    public Guid ContinentId { get; set; }

    [Display(Name = "SubcontinentPopulation")]
    public Int64 Population { get; set; }

    [Display(Name = "SubcontinentRemarks")]
    public String Remarks { get; set; }
}
