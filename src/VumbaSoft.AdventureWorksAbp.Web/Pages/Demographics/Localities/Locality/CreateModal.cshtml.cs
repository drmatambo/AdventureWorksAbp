using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorksAbp.Demographics.Localities;
using VumbaSoft.AdventureWorksAbp.Demographics.Localities.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Localities.Locality.ViewModels;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Localities.Locality;

public class CreateModalModel : AdventureWorksAbpPageModel
{
    [BindProperty]
    public CreateLocalityViewModel ViewModel { get; set; }

    private readonly ILocalityAppService _service;

    public CreateModalModel(ILocalityAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateLocalityViewModel, CreateLocalityDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}