using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Countries.Country.ViewModels;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Countries.Country;

public class EditModalModel : AdventureWorksAbpPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public EditCountryViewModel ViewModel { get; set; }
    //public List<SelectListItem> CountryContinents { get; set; }
    //public List<SelectListItem> CountrySubContinents { get; set; }

    private readonly ICountryAppService _service;

    public EditModalModel(ICountryAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        //ViewModel = new EditCountryViewModel();

        //Get Continent lookup list
        //var continentLookup = await _service.GetContinentLookupAsync();
        //CountryContinents = continentLookup.Items
        //    .OrderBy(y => y.Name)
        //    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
        //    .ToList();

        //Get subcontinent lookup list
        //var subContinentLookup = await _service.GetSubContinentLookupAsync();
        //CountrySubContinents = subContinentLookup.Items
        //    .OrderBy(y => y.Name)
        //    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
        //    .ToList();

        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<CountryDto, EditCountryViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditCountryViewModel, UpdateCountryDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}