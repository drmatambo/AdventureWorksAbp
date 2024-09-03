using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VumbaSoft.AdventureWorksAbp.Demographics.Regions;
using VumbaSoft.AdventureWorksAbp.Demographics.Regions.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Regions.Region.ViewModels;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Regions.Region;

public class CreateModalModel : AdventureWorksAbpPageModel
{
    [BindProperty]
    public CreateRegionViewModel ViewModel { get; set; }

    public List<SelectListItem> RegionContinents { get; set; }
    public List<SelectListItem> RegionSubContinents { get; set; }
    public List<SelectListItem> RegionCountries { get; set; }

    private readonly IRegionAppService _service;

    public CreateModalModel(IRegionAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        ViewModel = new CreateRegionViewModel();

        //Continent Look List
        var ContinentLookUp = await _service.GetRegionContinentLookupAsync();
        RegionContinents = ContinentLookUp.Items
            .OrderBy(x => x.Name)
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();

        // Subcontinent Lookup List
        var SubContinentLookUp = await _service.GetRegionSubContinentLookupAsync();
        RegionSubContinents = SubContinentLookUp.Items
            .OrderBy(x => x.Name)
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();


        // Country Lookup List
        var CountryLookUp = await _service.GetRegionCountryLookupAsync();
        RegionCountries = CountryLookUp.Items
            .OrderBy(y => y.Name)
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateRegionViewModel, CreateRegionDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}