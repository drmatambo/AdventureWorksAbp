using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces;
using VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.StateProvinces.StateProvince.ViewModels;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.StateProvinces.StateProvince;

public class CreateModalModel : AdventureWorksAbpPageModel
{
    [BindProperty]
    public CreateStateProvinceViewModel ViewModel { get; set; }
    public List<SelectListItem> StateProvinceRegions { get; set; }
    public List<SelectListItem> StateProvinceCountries { get; set; }

    private readonly IStateProvinceAppService _service;

    public CreateModalModel(IStateProvinceAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        ViewModel = new CreateStateProvinceViewModel();

        var CountryLookUp = await _service.GetStateProvinceCountryLookupAsync();
        
        StateProvinceCountries = CountryLookUp.Items
            .OrderBy(y => y.Name)
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();

        var RegionLookUp = await _service.GetStateProvinceRegionLookupAsync();
        
        StateProvinceRegions = RegionLookUp.Items
            .OrderBy(y => y.Name)
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();

    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateStateProvinceViewModel, CreateStateProvinceDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}