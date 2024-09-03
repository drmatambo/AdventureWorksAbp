using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities;
using VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.DistrictCities.DistrictCity.ViewModels;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.DistrictCities.DistrictCity;

public class CreateModalModel : AdventureWorksAbpPageModel
{
    [BindProperty]
    public CreateDistrictCityViewModel ViewModel { get; set; }

    public List<SelectListItem> DistrictCityContinents { get; set; }
    public List<SelectListItem> DistrictCitySubcontinents { get; set; }
    public List<SelectListItem> DistrictCityCountries { get; set; }
    public List<SelectListItem> DistrictCityRegions { get; set; }
    public List<SelectListItem> DistrictCityStateProvinces { get; set; }

    private readonly IDistrictCityAppService _service;

    public CreateModalModel(IDistrictCityAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        ViewModel = new CreateDistrictCityViewModel();

        var continentLookUp = await _service.GetDistrictCityContinentLookupAsync();
        DistrictCityContinents = continentLookUp.Items
            .OrderBy(x => x.Name)
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();

        var subcontinentLooUp = await _service.GetDistrictCitySubcontinentLookupAsync();
        DistrictCitySubcontinents = subcontinentLooUp.Items
            .OrderBy(x => x.Name)
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();  

        var countryLookUp = await _service.GetDistrictCityCountryLookupAsync();
        DistrictCityCountries = countryLookUp.Items
            .OrderBy(y => y.Name)
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();

        var regionLookUp = await _service.GetDistrictCityRegionLookupAsync();
        DistrictCityRegions = regionLookUp.Items
            .OrderBy(x => x.Name)
            .Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();

        var ProvinceLookUp = await _service.GetDistrictCityStateProvinceLookupAsync();
        DistrictCityStateProvinces = ProvinceLookUp.Items
            .OrderBy(y => y.Name)
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateDistrictCityViewModel, CreateDistrictCityDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}