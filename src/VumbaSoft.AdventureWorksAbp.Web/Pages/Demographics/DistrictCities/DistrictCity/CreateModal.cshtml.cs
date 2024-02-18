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
    public List<SelectListItem> Provinces { get; set; }
    public List<SelectListItem> Countries { get; set; }

    private readonly IDistrictCityAppService _service;

    public CreateModalModel(IDistrictCityAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        ViewModel = new CreateDistrictCityViewModel();

        var provinceLookUp = await _service.GetDistrictCityStateProvinceLookupAsync();
        Provinces = provinceLookUp.Items
            .OrderBy(y => y.Name)
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();

        var countriesLookUp = await _service.GetDistrictCityCountryLookupAsync();
        Countries = countriesLookUp.Items
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