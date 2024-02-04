using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Continents.Continent.ViewModels;

public class CreateContinentViewModel
{
    [Display(Name = "ContinentName")]
    public String Name { get; set; }

    [Display(Name = "ContinentPopulation")]
    public Int64 Population { get; set; }

    [Display(Name = "ContinentRemarks")]
    public String Remarks { get; set; }
}
