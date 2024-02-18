using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VumbaSoft.AdventureWorksAbp.Demographics.Regions;
using VumbaSoft.AdventureWorksAbp.Demographics.Regions.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Regions.Region.ViewModels;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Regions.Region;

public class EditModalModel : AdventureWorksAbpPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public EditRegionViewModel ViewModel { get; set; }
    //public List<SelectListItem> RegionCountries { get; set; }

    private readonly IRegionAppService _service;

    public EditModalModel(IRegionAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        //var CountryLookUp = await _service.GetRegionCountryLookupAsync();
        //RegionCountries = CountryLookUp.Items
        //    .OrderBy(y => y.Name)
        //    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
        //    .ToList();

        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<RegionDto, EditRegionViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditRegionViewModel, UpdateRegionDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}