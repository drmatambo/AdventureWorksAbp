using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Countries.Country.ViewModels;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Countries.Country;

public class CreateModalModel : AdventureWorksAbpPageModel
{
    [BindProperty]
    public CreateCountryViewModel ViewModel { get; set; }
    public List<SelectListItem> CountryContinents { get; set; }
    public List<SelectListItem> CountrySubContinents { get; set; }

    private readonly ICountryAppService _countryService;
    private readonly ICountryAppService _subcontinentService;

    //public CreateModalModel(ICountryAppService service)
    //{
    //    _service = service;
    //}

    public CreateModalModel(ICountryAppService countryService, ICountryAppService subcontinentService)
    {
        _countryService = countryService;
        _subcontinentService = subcontinentService;
    }

    public virtual async Task OnGetAsync()
    {
        ViewModel = new CreateCountryViewModel();

        var continentLookup = await _countryService.GetContinentLookupAsync();
        CountryContinents = continentLookup.Items
            .OrderBy(y=>y.Name)
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();

        //var subContinentLookup = await _subcontinentService.GetListAsync(input:ViewModel);

        //var subContinentLookup = await _countryService.GetSubContinentLookupAsync();
        CountrySubContinents = subContinentLookup.Items
            .OrderBy(y => y.Name)
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateCountryViewModel, CreateCountryDto>(ViewModel);
        await _countryService.CreateAsync(dto);
        return NoContent();
    }
}