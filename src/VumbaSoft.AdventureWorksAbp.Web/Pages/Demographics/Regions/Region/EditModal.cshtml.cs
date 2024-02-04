using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

    private readonly IRegionAppService _service;

    public EditModalModel(IRegionAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
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