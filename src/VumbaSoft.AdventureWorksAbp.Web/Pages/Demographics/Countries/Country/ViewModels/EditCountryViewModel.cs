using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Countries.Country.ViewModels;

public class EditCountryViewModel
{
    [Display(Name = "CountryContinentId")]
    public Guid ContinentId { get; set; }

    [Display(Name = "CountrySubcontinentId")]
    public Guid SubcontinentId { get; set; }

    [Display(Name = "CountryName")]
    public String Name { get; set; }

    [Display(Name = "CountryFormalName")]
    public String FormalName { get; set; }

    [Display(Name = "CountryNativeName")]
    public String NativeName { get; set; }

    [Display(Name = "CountryIsoTreeCode")]
    public String IsoTreeCode { get; set; }

    [Display(Name = "CountryIsoTwoCode")]
    public String IsoTwoCode { get; set; }

    [Display(Name = "CountryCcnTreeCode")]
    public String CcnTreeCode { get; set; }

    [Display(Name = "CountryPhoneCode")]
    public String PhoneCode { get; set; }

    [Display(Name = "CountryCapital")]
    public String Capital { get; set; }

    [Display(Name = "CountryCurrency")]
    public String Currency { get; set; }

    [Display(Name = "CountryPopulation")]
    public Int64 Population { get; set; }

    [Display(Name = "CountryEmoji")]
    public String Emoji { get; set; }

    [Display(Name = "CountryEmojiU")]
    public String EmojiU { get; set; }

    [Display(Name = "CountryRemarks")]
    public String Remarks { get; set; }
}
