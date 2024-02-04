using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorksAbp.Demographics.Continents;
using VumbaSoft.AdventureWorksAbp.Demographics.Continents.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Continents.Continent.ViewModels;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Continents.Continent;

public class EditModalModel : AdventureWorksAbpPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public EditContinentViewModel ViewModel { get; set; }

    private readonly IContinentAppService _service;

    public EditModalModel(IContinentAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<ContinentDto, EditContinentViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditContinentViewModel, UpdateContinentDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}