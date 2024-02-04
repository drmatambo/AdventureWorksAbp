using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorksAbp.Demographics.Regions;
using VumbaSoft.AdventureWorksAbp.Demographics.Regions.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Regions.Region.ViewModels;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Regions.Region;

public class CreateModalModel : AdventureWorksAbpPageModel
{
    [BindProperty]
    public CreateRegionViewModel ViewModel { get; set; }

    private readonly IRegionAppService _service;

    public CreateModalModel(IRegionAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateRegionViewModel, CreateRegionDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}