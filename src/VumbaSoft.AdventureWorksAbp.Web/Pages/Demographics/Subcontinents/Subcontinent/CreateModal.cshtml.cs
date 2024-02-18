using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;
using VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Subcontinents.Subcontinent.ViewModels;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Subcontinents.Subcontinent;

public class CreateModalModel : AdventureWorksAbpPageModel
{
    [BindProperty]
    public CreateSubcontinentViewModel ViewModel { get; set; }

    public List<SelectListItem> Continents { get; set; } = new List<SelectListItem>();

    private readonly ISubcontinentAppService _service;

    public CreateModalModel(ISubcontinentAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        ViewModel = new CreateSubcontinentViewModel();

        var continentLookup = await _service.GetContinentLookupAsync();

        Continents = continentLookup.Items
            .OrderBy(y => y.Name)
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateSubcontinentViewModel, CreateSubcontinentDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}