using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorksAbp.Demographics.Continents;
using VumbaSoft.AdventureWorksAbp.Demographics.Continents.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Continents.Continent.ViewModels;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Continents.Continent;

public class CreateModalModel : AdventureWorksAbpPageModel
{
    [BindProperty]
    public CreateContinentViewModel ViewModel { get; set; }

    private readonly IContinentAppService _service;

    public CreateModalModel(IContinentAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateContinentViewModel, CreateContinentDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}